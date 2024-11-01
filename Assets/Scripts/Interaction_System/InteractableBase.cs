using System.Collections;
using System.Collections.Generic;
using TF;
using UnityEngine;

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

        [SerializeField] private string tooltipMessage = "interact";
        #endregion

        #region Properties
            public float HoldDuration => holdDuration;
            //Simplified for:
            //get
            //{
            //  return holdDuriation;
            //}
            public bool HoldInteract => holdInteract;
            public bool MultipleUse => multipleUse;
            public bool IsInteractable => isInteractable;
            public string TooltipMessage => tooltipMessage;
        #endregion

        #region Methods
        public virtual void OnInteract()
        {
            Debug.Log("INTERACTED: " + gameObject.name);
        }
        #endregion
    }
}
