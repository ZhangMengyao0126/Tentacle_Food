using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TF
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
    //ScriptableObject: A class that allows you to create data containers that can be saved as assets in your project, it's like a blueprint for data assets.
    ////////////////////Unlike MonoBehaviour scripts, which need to be attached to GameObjects in a scene,
    ////////////////////ScriptableObject instances live as assets in your Unity project.
    {
        private bool m_interactedClicked;
        //m_: A habit to show this is a private variable.
        private bool m_interactedRelease;

        public bool InteractedClicked
        //Using property instead of public variable: Better way to encapsulate your code.
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
            //Simplified version for:
            //get: Used to return the private field's value.
            //get
            //{
            //    return (m_interactedCliked);
            //}
            //set: Used to set the private field's value to the value that we assigned from other script.
            //set
            //{
            //    m_interactedClicked = value;
            //}
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
