using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TF
{    
    public class InputHandler : MonoBehaviour
    // MonoBehaviour: A base class in Unity that allows the script to be attached to GameObjects and provides methods to respond to Unity events.
    {
        #region Data
        public InteractionInputData interactionInputData;
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
