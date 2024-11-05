using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TF
{
    public class DestroyInteractable : InteractableBase
    {
        public override void OnInteract()
        //When you use the override keyword,
        //you can either replace or extend the behavior of the OnInteract method
        //from the base class (InteractableBase) in your derived class (DestroyInteractable).
        {
            base.OnInteract();

            Destroy(gameObject);        
        }
    }
}
