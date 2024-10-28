using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{
    public class InteractableBase : MonoBehaviour, IInteractable
    {
        #region Variables
            private bool holdInteract = true;
            private float holdDuriation = 3f;
            
            private bool multipleUse = false;
            private bool isInteractable = true;
        #endregion

        #region Properties
            public float HoldDuration => holdDuriation;
            public bool HoldInteract => holdInteract;
            public bool MultipleUse => multipleUse;
            public bool IsInteractable => isInteractable;
        #endregion

        #region Methods
        public virtual void OnInteract()
        {
            Debug.Log("INTERACTED: " + gameObject.name);
        }
        #endregion
    }
}
