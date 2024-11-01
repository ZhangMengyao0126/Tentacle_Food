using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TF
//Namespace: A collection of name definitions of classes,interfaces, methods, and variables.
/////////////The same namespace shares all the names within it.
{
    public interface IInteractable
//Interface: A contract that specifies a set of rules or a protocol that classes must follow if they choose to implement that interface.
/////////////For IInteractable, it includes all the variables that will be needed in every interactable.
    {
        float HoldDuration { get; }
        //{ get; }:A get accessor, meaning it's a read-only property.
        //We are using properties, because interface does not accept fields(variables).
        bool HoldInteract { get; }
        //Objects can only be interacted with only once.
        bool MultipleUse { get; }
        //Objects can be interacted with multiple times.
        bool IsInteractable { get; }
        string TooltipMessage { get; }

        void OnInteract();
        //Every class that implements this interface should have this method.
    }
}
