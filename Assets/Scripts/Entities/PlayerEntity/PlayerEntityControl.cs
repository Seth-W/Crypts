using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the behavior for responding to User Input for a Player Entity
    *</summary>
    */
    class PlayerEntityControl : ObjectControl
    {
        public delegate void OnHoverOff();
        public delegate void OnHoverOn();
        public delegate void OnMouseUp();
        public delegate void OnMouseDown();

        public event OnHoverOff PlayerEntityHoverOffEvent;
        public event OnHoverOn PlayerEntityHoverOnEvent;
        public event OnMouseUp PlayerEntityMouseUpEvent;
        public event OnMouseDown PlayerEntityMouseDownEvent;

        public override void HoverOff()
        {
            //Debug.Log("Called HoverOff for " + this);
            PlayerEntityHoverOffEvent();
        }

        public override void HoverOn()
        {
            //Debug.Log("Called HoverOn for " + this);
            PlayerEntityHoverOnEvent();
        }

        public override void MouseDown()
        {
            //Debug.Log("Called MouseDown for " + this);
            PlayerEntityMouseDownEvent();
        }

        public override void MouseUp()
        {
            //Debug.Log("Called MouseUp for " + this);
            PlayerEntityMouseUpEvent();
        }
    }
}
