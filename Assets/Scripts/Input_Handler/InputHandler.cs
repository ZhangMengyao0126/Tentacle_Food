using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TF
{    
    public class InputHandler : MonoBehaviour
    //MonoBehaviour: A base class in Unity that allows the script to be attached to GameObjects and provides methods to respond to Unity events.
    //We attached this script to an empty gameobject, which is still a valid GameObject, meaning it can be activated in the scene.
    //When the scene starts, Unity enables all active GameObjects and their components (including our InputHandler script).
    {
        #region Data
        public InteractionInputData interactionInputData;
        //This is also a reference.
        //Since InteractionInputData is a ScriptableObject, we can only access it through an instance of it.
        #endregion

        #region BuiltIn Methods
        void Start()
        //void: A method does not return any value.
        //Start: A built-in method that is automatically called once when a script instance is enabled, right before the first frame update.
        /////////Only for one time.
        {
            interactionInputData.ResetInput();
        }

        void Update()
        //Update: A built-in method that is called once per frame.
        {
            GetInteractionInputData();
        }
        #endregion

        #region Custom Methods
        void GetInteractionInputData()
        {
            interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
            interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
        }
        #endregion
    }
}
