using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace VHS
{
    [CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]
    //CreateAssetMenu: Create instances of your ScriptableObject directly from the Unity Editor.
    //fileName: The defalt name of the new ScriptableObject.
    //menuName: Where in the Create Asset menu this option will appear in the Unity Editor(Create ¡ú InteractionSystem ¡ú InputData).
    public class InteractionInputData : ScriptableObject
    //":":
    //1. Class Inheritance:
    /////When a class is followed by a : and another class name, it means the class inherits from the specified base class.
    /////This means it will inherit all the methods and properties of the base class, allowing it to reuse and potentially override those methods.
    //2. Interface Implementation:
    /////When a class is followed by : and an interface name, it means the class implements the specified interface.
    /////This requires the class to define all methods and properties specified in the interface, 
    /////following a ¡°contract¡± of required methods and properties.
    //ScriptableObject: A class that allows you to create data containers that can be saved as assets in your project.
    {
        private bool m_interactedClicked;
        private bool m_interactedRelease;

        public bool InteractedClicked
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
        }

        public bool InteractedRelease
        {
            get => m_interactedRelease;
            set => m_interactedRelease = value;
        }

        public void ResetInput()
        {
            m_interactedClicked = false;
            m_interactedRelease = false;
        }

    }
}
