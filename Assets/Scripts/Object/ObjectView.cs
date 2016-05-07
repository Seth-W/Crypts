using System;
using UnityEngine;

namespace CFE
{
    abstract class ObjectView : MonoBehaviour
    {

        bool _active;
        public bool active
        {
            get { return _active; }
            set { setActive(value); }
        }

        public abstract void HoverOn();
        public abstract void HoverOff();
        public abstract void MouseDown();
        public abstract void MouseUp();
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
