using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{    
    public class InputHandler : MonoBehaviour
   {
        #region Data
        public InteractionInputData interactionInputData;
        #endregion

        #region BuiltIn Methods
        void Start()
        {
            interactionInputData.ResetInput();
        }

        void Update()
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
