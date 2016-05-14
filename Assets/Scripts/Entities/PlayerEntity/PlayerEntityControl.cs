using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the behavior for responding to User Input for a Player Entity
    *</summary>
    */
    class PlayerEntityControl : MonoBehaviour, IObjectControl
    {
        public delegate void OnHoverOff();
        public delegate void OnHoverOn();
        public delegate void OnMouseUp();
        public delegate void OnMouseDown();
        public delegate void OnMouseDownRevert();

        public event OnHoverOff PlayerEntityHoverOffEvent;
        public event OnHoverOn PlayerEntityHoverOnEvent;
        public event OnMouseUp PlayerEntityMouseUpEvent;
        public event OnMouseDown PlayerEntityMouseDownEvent;
        public event OnMouseDownRevert PlayerEntityMouseDownRevertEvent;

        /**
        *<summary>
        *Called on the first frame that a ray cast from the mouse's position on the screen no longer collides with this object
        *</summary>
        */
        public void HoverOff()
        {
            //Debug.Log("Called HoverOff for " + this);
            PlayerEntityHoverOffEvent();
        }

        /**
        *<summary>
        *Called on the frame when a ray cast from the mouse's position on the screen first collides with this object
        *</summary>
        */
        public void HoverOn()
        {
            //Debug.Log("Called HoverOn for " + this);
            PlayerEntityHoverOnEvent();
        }

        /**
        *<summary>
        *Called on the first frame that the left mouse button is pressed while a ray cast from the
        *mouse's position on the screen collides with this object
        *</summary>
        */
        public void MouseDown()
        {
            //Debug.Log("Called MouseDown for " + this);
            PlayerEntityMouseDownEvent();
        }

        /**
        *<summary>
        *Called on the first frame that the left mouse button is released after MouseDown() has been called
        *</summary>
        */
        public void MouseUp()
        {
            //Debug.Log("Called MouseUp for " + this);
            PlayerEntityMouseUpEvent();
        }

        /**
        *<summary>
        *Called on the first frame for the mouseclicked object that
        *-- while the left mouse button is held down-- 
        *the mousepicked object does not equal the mouseclicked object
        *</summary>
        */
        public void MouseDownRevert()
        {
            //Debug.Log("Called MouseDownRevert for " + this);
            PlayerEntityMouseDownRevertEvent();
        }
    }
}
