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
        }

        public virtual void Start()
        {
            view = GetComponent<ObjectView>();
            if (view == null)
                Debug.LogError("Could not find an ObjectView component on " + this.gameObject);
        }



        public virtual void Enable()
        {
            _active = true;
            view.OnEnable();
        }
        public virtual void Disable()
        {
            _active = false;
            view.OnDisable();
        }
    }
}
