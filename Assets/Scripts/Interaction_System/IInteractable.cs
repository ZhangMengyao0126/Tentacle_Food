using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
//Namespace: A collection of name definitions of classes,interfaces, methods, and variables.
{
    public interface IInteractable
    //Interface: A contract that specifies a set of rules or a protocol that classes must follow if they choose to implement that interface. 
    {
        float HoldDuration { get; }
        //{ get; }:A get accessor, meaning it's a read-only property.

        bool HoldInteract { get; }
        bool MultipleUse { get; }
        bool IsInteractable { get; }
        string TooltipMessage { get; }

        void OnInteract();
    }
}
