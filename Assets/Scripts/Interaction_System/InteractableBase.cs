using System.Collections;
using System.Collections.Generic;
using TF;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.Rendering.DebugUI;

namespace TF
{
    public class InteractableBase : MonoBehaviour, IInteractable
    //IInteractable: Right click on the interface that the class implements can show a quick way to create all the principles it requests.
    {
        #region Variables
        [Space, Header("Interactable Settings")]

        [SerializeField] private bool holdInteract = true;
        [SerializeField] private float holdDuration = 3f;

        [Space]
        [SerializeField] private bool multipleUse = false;
        [SerializeField] private bool isInteractable = true;

        //you can assign a static value (like a number, string, or reference) to a field directly during initialization,
        //but you cannot call methods that rely on the Unity lifecycle (like GetComponent, Instantiate, etc.) during field initialization.

        [SerializeField] private string tooltipMessage = "interact";
        //[SerializeField]:
        //Allows private fields to be visible and editable in the Unity Inspector while still maintaining their private access level.
        //This means you can set the value of the property in the Inspector when you create a GameObject with the component attached,
        //even though the field itself is private and can't be accessed from outside that class.
        #endregion
        #region Properties
        //A good habit: These provide read-only access to the private fields defined above,
        ////////////////making them accessible to other classes while keeping the fields themselves encapsulated.
        public float HoldDuration => holdDuration;
        //Simplified for:
        //get
        //{
        //  return holdDuriation;
        //}
        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;
        public string TooltipMessage
        {
            get => tooltipMessage;
            set => tooltipMessage = value;
        }
        #endregion

        #region Methods
        public virtual void OnInteract()
        //virtual: means this method can be overridden by any derived classes.
        {
            Debug.Log("INTERACTED: " + gameObject.name);
        }
        #endregion
    }
}
