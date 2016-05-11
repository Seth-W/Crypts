using System;
using UnityEngine;

namespace CFE
{
    abstract class ObjectView : MonoBehaviour
    {
        public Renderer rend;
        ObjectModel model;
        protected bool active { get { return model.active; } }


        public virtual void Start()
        {
            rend = GetComponent<Renderer>();
            if (rend == null)
                Debug.LogError("Could not find a Renderer component on " + this.gameObject);
            model = GetComponent<ObjectModel>();
            if (model == null)
                Debug.LogError("Could not find an ObjectModel component on " + this.gameObject);
        }


        public virtual void OnHoverOn()
        { }
        public virtual void OnHoverOff()
        { }
        public virtual void OnMouseDown()
        { }
        public virtual void OnMouseUp()
        { }
        public virtual void OnEnable()
        { }
        public virtual void OnDisable()
        { }

    }
}
