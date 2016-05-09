using UnityEngine;

namespace CFE
{
    abstract class ObjectControl : MonoBehaviour
    {
        protected ObjectModel model;
        protected ObjectView view;

        void Start()
        {
            model = GetComponent<ObjectModel>();
            if (model == null)
                Debug.LogError("Could not find an ObjectModel component on " + this.gameObject);
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }

        public virtual void HoverOn()
        {
            view.OnHoverOn();
        }
        public virtual void HoverOff()
        {
            view.OnHoverOff();
        }
        public virtual void MouseDown()
        {
            view.OnMouseDown();
        }
        public virtual void MouseUp()
        {
            view.OnMouseUp();
        }
    }
}
