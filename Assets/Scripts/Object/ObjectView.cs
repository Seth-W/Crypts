using System;
using UnityEngine;

namespace CFE
{
    abstract class ObjectView : MonoBehaviour
    {
        protected Renderer rend;

        public virtual void Start()
        {
            rend = GetComponent<Renderer>();
        }


        public abstract void OnHoverOn();
        public abstract void OnHoverOff();
        public abstract void OnMouseDown();
        public abstract void OnMouseUp();
        public abstract void OnEnable();
        public abstract void OnDisable();

    }
}
