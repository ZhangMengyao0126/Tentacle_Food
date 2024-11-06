using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TF
{
    public class PickupInteractable : InteractableBase
    {
        public GameObject player;
        public Transform holdPos;
        private GameObject heldObj;
        private Rigidbody heldObjRb;
        private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
        private bool canDrop = false;

        public override void OnInteract()
        //When you use the override keyword,
        //you can either replace or extend the behavior of the OnInteract method
        //from the base class (InteractableBase) in your derived class (DestroyInteractable).
        {
            base.OnInteract();
            if (!canDrop)
            {
                PickUpObject(gameObject);
                TooltipMessage = "DROP";
                canDrop = true;
            }
            else
            {
                DropObject();
                TooltipMessage = "PICK";
                canDrop = false;
            }
            //Why can't I use PickupInteractable.TooltipMessage = "DROP"?
            //Since TooltipMessage is defined as an instance property in InteractableBase,
            //every class that inherits from InteractableBase (like PickupInteractable) will also inherit this property.
            //So, the you can directly use TooltipMessage within PickupInteractable without any additional declaration.
        }
        void Update()
        {
            if (Input.GetKey(KeyCode.R))
            {
                Debug.Log("R key pressed inside Update!");
                RotateObject();
            }
        }
        void PickUpObject(GameObject pickUpObj)
        {
            if (pickUpObj.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
            {
                heldObj = pickUpObj; //assign heldObj to the object that was hit by the raycast (no longer == null)
                heldObjRb = pickUpObj.GetComponent<Rigidbody>(); //assign Rigidbody
                heldObjRb.isKinematic = true;
                heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
                Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
            }
            else
            {
                Debug.LogWarning("Picked object does not have a Rigidbody component!");
            }
        }
        void DropObject( )
        {
            //re-enable collision with player
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
            heldObjRb.isKinematic = false;
            heldObj.transform.parent = null; //unparent object
            heldObj = null; //undefine game object
        }

        void RotateObject()
        {
            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            heldObj.transform.Rotate(Vector3.down, XaxisRotation);
            heldObj.transform.Rotate(Vector3.right, YaxisRotation);
        }
    }
}
