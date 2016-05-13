using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Base Control class for all objects that the mouse can interact with
    *Contains behaviors to for mouse HoverOn/off MouseUp/Down
    *</summary>
    */
    abstract class ObjectControl : MonoBehaviour
    {
        protected ObjectModel model;
        protected ObjectView view;

        public virtual void Start()
        {
            //Assign the gameObjects ObjectModel componenet to model
            model = GetComponent<ObjectModel>();
            if (model == null)
                Debug.LogError("Could not find an ObjectModel component on " + this.gameObject);

            //Assign the gameObjects ObjectView componenet to view
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }
        /**
        *<summary>
        *Called on the frame when a ray cast from the mouse's position on the screen first collides with this object
        *</summary>
        */
        public abstract void HoverOn();
        /**
        *<summary>
        *Called on the first frame that a ray cast from the mouse's position on the screen no longer collides with this object
        *</summary>
        */
        public abstract void HoverOff();
        /**
        *<summary>
        *Called on the first frame that the left mouse button is pressed while a ray cast from the
        *mouse's position on the screen collides with this object
        *</summary>
        */
        public abstract void MouseDown();
        /**
        *<summary>
        *Called on the first frame that the left mouse button is released after MouseDown() has been called
        *</summary>*/
        public abstract void MouseUp();
    }
}
