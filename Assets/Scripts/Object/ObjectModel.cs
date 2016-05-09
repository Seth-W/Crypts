using UnityEngine;

namespace CFE
{
    abstract class ObjectModel : MonoBehaviour
    {
        protected ObjectView view;

        bool _active;
        public bool active
        {
            get { return _active; }
            set { setActive(value); }
        }

        void Start()
        {
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }

        protected void setActive(bool b)
        {
            _active = b;
            if (b)
                Enable();
            else
                Disable();
        }

        public abstract void Enable();
        public abstract void Disable();
    }
}
