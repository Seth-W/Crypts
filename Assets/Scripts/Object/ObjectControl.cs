using UnityEngine;

namespace CFE
{
    abstract class ObjectControl : MonoBehaviour
    {
        protected ObjectModel model;
        protected ObjectView view;

        public virtual void Start()
        {
            model = GetComponent<ObjectModel>();
            if (model == null)
                Debug.LogError("Could not find an ObjectModel component on " + this.gameObject);
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }
        /**
        *<summary>Called on the frame when a ray cast from the mouse's position on the screen first collides with this object</summary>
        */
        public virtual void HoverOn()
        {
            view.OnHoverOn();
        }
        /**
        *<summary>Called on the first frame that a ray cast from the mouse's position on the screen no longer collides with this object</summary>
        */
        public virtual void HoverOff()
        {
            view.OnHoverOff();
        }
        /**
        *<summary>Called on the first frame that the left mouse button is pressed while a ray cast from the
         mouse's position on the screen collides with this object</summary>
        */
        public virtual void MouseDown()
        {
            view.OnMouseDown();
        }
        /**
        *<summary>Called on the first frame that the left mouse button is released after MouseDown() has been called</summary>
        */
        public virtual void MouseUp()
        {
            view.OnMouseUp();
        }
    }
}
