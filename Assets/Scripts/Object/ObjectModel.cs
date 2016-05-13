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

        public virtual void Start()
        {
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }



        public abstract void Activate();
        public abstract void Deactivate();

        private void setActive(bool b)
        {
            if (_active = b)
                return;
            _active = b;
            if (b)
                Activate();
            else
                Deactivate();
        }
    }
}
