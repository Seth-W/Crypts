using System;
using UnityEngine;

namespace CFE
{
    /**
    *Abstract base class for 3D button objects
    *Contains default visual behavior for 3D buttons
    */
    abstract class ButtonView3D : MonoBehaviour, IObjectView
    {


        public virtual void OnEnable()
        { 
        }

        public virtual void OnDisable()
        {

        }
        
        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse hovers over this gameObject
        *</summary>
        */
        public virtual void OnHoverOn()
        {
            Debug.LogWarning("Called OnHoverOn for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse is no longer hovering over this gameObject when it previously had been
        *</summary>
        */
        public virtual void OnHoverOff()
        {
            Debug.LogWarning("Called OnHoverOff for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks down while hovering over this gameObject
        *</summary>
        */
        public virtual void OnMouseDown()
        {
            Debug.Log("Called OnMouseDown for " + this);
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos;
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks up after left clicking down on this object
        *</summary>
        */
        public virtual void OnMouseUp()
        {
            Debug.Log("Called OnMouseUp for " + this);
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public virtual void OnActivate()
        {
            Debug.LogWarning("Called OnActivate for" + this + ";  \n OnActivate not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public virtual void OnDeactivate()
        {
            Debug.LogWarning("Called OnDeactivate for" + this + ";  \n OnDeactivate not implemented");
        }

        public virtual void OnMouseDownRevert()
        {
            Debug.Log("Called OnMouseDownRevert for " + this);
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }
    }
}
