using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        #region Variables
            [Space, Header("Interactable Settings")]

            [SerializeField] private bool holdInteract = true;
            [SerializeField] private float holdDuriation = 3f;

            [Space]
            [SerializeField] private bool multipleUse = false;
            [SerializeField] private bool isInteractable = true;

        [SerializeField] private string tooltipMessage = "interact";
        #endregion

        #region Properties
            public float HoldDuration => holdDuriation;
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
