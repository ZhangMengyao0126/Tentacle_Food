using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace TF
{
    public class InteractionController : MonoBehaviour
    {
        #region Variables
        [Space, Header("Data")]
        [SerializeField] private InteractionInputData interactionInputData;
        [SerializeField] private InteractionData interactionData;
        //Those are references here.
        //In Unity, an instance of InteractionInputData (e.g., named "A" in the Project window) is simply an asset.
        //When you assign this asset to a reference variable in a script (like interactionInputData),
        //Unity links the reference to that specific asset instance.
        //However, the variable¡¯s name in your code is separate and only serves as an identifier within that script.

        [Space, Header("UI")]
        [SerializeField] private InteractionUIPanel uiPanel;

        [Space, Header("Ray Settings")]
        [SerializeField] private float rayDistance;
        [SerializeField] private float raySphereRadius;
        [SerializeField] private LayerMask interactableLayer;
        //The layer the raycast should check, so only objects in the interactable layer are detected.
        #region Private
        private Camera m_cam;
        private bool m_interacting;
        private float m_holdTimer = 0f;
            #endregion

        #endregion

        #region Built In Methods
        private void Awake()
        {
            m_cam = FindObjectOfType<Camera>();
            //The m_cam is set to the main camera, which will serve as the ray origin for detecting interactable objects.
        }

        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }
        #endregion

        #region Custom Methods
        void CheckForInteractable()
        {
            Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
            //Creates a ray that starts at the camera's position and projects forward(m_cam.transform.forward)
            RaycastHit _hitInfo;
            //RaycastHit: includes hitInfo.point; hitInfo.normal; hitInfo.transform; hitInfo.collider.

            bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo,
            rayDistance, interactableLayer);
            //Physics.SphereCast: A unity method that detects objects in a scene along a given path by casting a virtual sphere with a defined radius.
            //_ray: A ray object that defines the starting point and direction for the sphere cast.
            //raySphereRadius: A float that defines the radius of the imaginary sphere.
            //out _hitInfo: An out parameter that stores information about what the sphere cast hit.
            //rayDistance: The maximum distance the sphere cast should travel.
            //interactableLayer: A layerMask that specifies which layers the sphere cast should consider.
            //Return value: true or false
            if (_hitSomething)
            {
                InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();
                //reference = the InteractableBase component on the object that was hit by the sphere cast

                if (_interactable != null)
                {
                    if (interactionData.IsEmpty())
                    {
                        interactionData.Interactable = _interactable;
                        //The public property will set the value of the private field m_interactable, so m_interactable = _interactable now.
                        uiPanel.SetTooltip(_interactable.TooltipMessage);
                    }
                    else
                    {
                        if (!interactionData.IsSameInteractable(_interactable))
                        {
                            interactionData.Interactable = _interactable;
                            uiPanel.SetTooltip(_interactable.TooltipMessage);
                        }
                    }
                }
            }
            else
            {
                uiPanel.RestUI();
                interactionData.ResetData();
            }

            Debug.DrawRay(_ray.origin,_ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }
        #endregion

        void CheckForInteractableInput()
        {
            if (interactionData.IsEmpty())
                return;

            if (interactionInputData.InteractedClicked)
            { 
                m_interacting = true;
                m_holdTimer = 0f;
            }

            if (interactionInputData.InteractedRelease)
            {
                m_interacting = false;
                m_holdTimer = 0f;
                uiPanel.UpdateProgressBar(0f);
            }

            if (m_interacting)
            {
                if (!interactionData.Interactable.IsInteractable)
                    return;
                if (interactionData.Interactable.HoldInteract)
                {
                    m_holdTimer += Time.deltaTime;

                    float heldPercent = m_holdTimer / interactionData.Interactable.HoldDuration;
                    uiPanel.UpdateProgressBar(heldPercent);

                    if (heldPercent >1f)
                    //1f: 100%
                    {
                        interactionData.Interact();
                        m_interacting = false;
                    }
                }
                else
                {
                    interactionData.Interact();
                    m_interacting = false;
                }
            }
        }
    }

}