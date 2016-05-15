using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the behavior for responding to User Input for an ActionButton
    *</summary>
    */
    class ActionButtonControl :MonoBehaviour, IObjectControl
    {
        public delegate void OnHoverOff();
        public delegate void OnHoverOn();
        public delegate void OnMouseDown();
        public delegate void OnMouseUp();
        public delegate void OnMouseDownRevert();

        public event OnHoverOff ActionButtonHoverOffEvent;
        public event OnHoverOn ActionButtonHoverOnEvent;
        public event OnMouseDown ActionButtonMouseDownEvent;
        public event OnMouseUp ActionButtonMouseUpEvent;
        public event OnMouseDownRevert ActionButtonMouseDownRevertEvent;



        /**
        *<summary>
        *Called on the first frame that a ray cast from the mouse's position on the screen no longer collides with this object
        *</summary>
        */
        public void HoverOff()
        {
            //Debug.Log("Called HoverOff for " + this);
            if(ActionButtonHoverOffEvent != null)
                ActionButtonHoverOffEvent();
        }

        /**
        *<summary>
        *Called on the frame when a ray cast from the mouse's position on the screen first collides with this object
        *</summary>
        */
        public void HoverOn()
        {
            //Debug.Log("Called HoverOn for " + this);
            if (ActionButtonHoverOnEvent != null)
                ActionButtonHoverOnEvent();
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
            if (ActionButtonMouseDownEvent != null)
                ActionButtonMouseDownEvent();
        }

        /**
        *<summary>
        *Called on the first frame that the left mouse button is released after MouseDown() has been called
        *</summary>
        */
        public void MouseUp()
        {
            //Debug.Log("Called MouseUp for " + this);
            if (ActionButtonMouseUpEvent != null)
                ActionButtonMouseUpEvent();
        }

        /**
        *<summary>
        *Called on the first frame for the mouseclicked object that
        *-- while the left mouse button is held down-- the mousepicked object does not equal the mouseclicked object
        *</summary>
        */
        public void MouseDownRevert()
        {
            //Debug.Log("Called MouseDownRevert for " + this);
            if (ActionButtonMouseDownRevertEvent != null)
                ActionButtonMouseDownRevertEvent();
        }
    }
}
