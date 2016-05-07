using System;
using UnityEngine;

namespace CFE
{
    abstract class ObjectView : MonoBehaviour
    {
        bool _active;
        bool active
        {
            get { return _active; }
            set { setActive(value); }
        }

        public abstract void OnHover();
        public abstract void OnClick();
        public abstract void OnRelease();
        public abstract void Enable();
        public abstract void Disable();

        protected void setActive(bool b)
        {
            _active = b;
            if (b)
                Enable();
            else
                Disable();
        }
    }
}
