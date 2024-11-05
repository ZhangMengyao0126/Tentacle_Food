using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace TF
{
    [CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
    public class InteractionData : ScriptableObject
    {
        private InteractableBase m_interactable;
        //A reference to a Monobehavior is a reference to an object, cause Monobehavior needs to be attached to a game object to function.

        public InteractableBase Interactable
        {
            get => m_interactable;
            set => m_interactable = value;
        }
        //Use the public property to get and set the value of private field m_interactable.

        public void Interact()
        {
            m_interactable.OnInteract();
            ResetData();
        }

        public bool IsSameInteractable(InteractableBase _newInteractable) => m_interactable == _newInteractable;
        //IsSameInteractable Method:
        //This method checks if the currently stored interactable (m_interactable) is the same as the new one passed as an argument (_newInteractable).
        //It returns true if they are the same object (i.e., if their references point to the same instance), and false otherwise.

        public bool IsEmpty() => m_interactable == null;
        //IsEmpty Method:
        //This method checks whether m_interactable is null, which indicates that there is currently no interactable object stored.
        //It returns true if it¡¯s empty, and false otherwise.

        public void ResetData() => m_interactable = null;
        //ResetData Method:
        //This method sets m_interactable to null, effectively clearing the stored interactable reference.
        //This could be useful after an interaction has occurred, to reset the state and prepare for the next interaction.
    }
}
