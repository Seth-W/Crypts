using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the behavior for responding to User Input for a Floor Entity
    *</summary>
    */
    class FloorEntityControl : ObjectControl
    {
        public delegate void OnHoverOff();
        public delegate void OnHoverOn();
        public delegate void OnMouseDown();
        public delegate void OnMouseUp();

        public event OnHoverOff FloorEntityHoverOffEvent;
        public event OnHoverOff FloorEntityHoverOnEvent;
        public event OnHoverOff FloorEntityMouseDownEvent;
        public event OnHoverOff FloorEntityMouseUpEvent;



        public override void HoverOff()
        {
            //Debug.Log("Called HoverOff for " + this);
            view.OnHoverOff();
        }

        public override void HoverOn()
        {
            //Debug.Log("Called HoverOn for " + this);
            view.OnHoverOn();
        }

        public override void MouseDown()
        {
            //Debug.Log("Called MouseDown for " + this);
            view.OnMouseDown();
        }

        public override void MouseUp()
        {
            //Debug.Log("Called MouseUp for " + this);
            view.OnMouseUp();
        }
    }
}
