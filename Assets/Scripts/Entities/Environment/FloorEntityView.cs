using System.Collections;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Controls the visual behavior of the environment floors
    *Responds to calls from an ObjectControl componenent for HoverOn/Off & MouseUp/Down
    *Responds to calls from an ObjectModel component for Activate/Deactivate
    *</summary>
    */
    class FloorEntityView : MonoBehaviour, IObjectView
    {
        FloorEntityModel model;
        FloorEntityControl control;
        Renderer rend;

        void OnEnable()
        {
            //Gets FloorEntityControl and Throws an Error if can't be found
            control = GetComponent<FloorEntityControl>();
            if (control == null)
            {
                Debug.LogError("Could not find a FloorEntityControl object " + gameObject);
                return;
            }
            //Gets FloorEntityModel and Throws an Error if can't be found
            model = GetComponent<FloorEntityModel>();
            if (control == null)
            {
                Debug.LogError("Could not find a FloorEntityModel object on " + gameObject);
                return;
            }
            //Gets renderer componenet and sends error if not found.
            //Does not end method if not found
            rend = GetComponent<Renderer>();
            if(rend == null)
            {
                Debug.LogError("Could not find a Renderer component on " + gameObject);
            }
            //Subscribe to FloorEntityModel events
            model.FloorEntityActivateEvent += OnDeactivate;
            model.FloorEntityDeactivateEvent += OnActivate;
            //Subscribe to FloorEntityControl events
            control.FloorEntityHoverOffEvent += OnHoverOff;
            control.FloorEntityHoverOnEvent += OnHoverOn;
            control.FloorEntityMouseUpEvent += OnMouseUp;
            control.FloorEntityMouseDownEvent += OnMouseDown;
        }

        void OnDisable()
        {
            //Unsubscribe to FloorEntityModel events
            model.FloorEntityActivateEvent -= OnDeactivate;
            model.FloorEntityDeactivateEvent -= OnActivate;
            //Unsubscribe to FloorEntityControl events
            control.FloorEntityHoverOffEvent -= OnHoverOff;
            control.FloorEntityHoverOnEvent -= OnHoverOn;
            control.FloorEntityMouseUpEvent -= OnMouseUp;
            control.FloorEntityMouseDownEvent -= OnMouseDown;
        }
        
        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse hovers over this gameObject
        *</summary>
        */
        public void OnHoverOn()
        {
            //Debug.Log("Called OnHoverOn for " + this);
            rend.material.color = Color.green;
        }

        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse is no longer hovering over this gameObject when it previously had been
        *</summary>
        */
        public void OnHoverOff()
        {
            //Debug.Log("Called OnHoverOff for " + this);
            rend.material.color = Color.grey;
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks down while hovering over this gameObject
        *</summary>
        */
        public void OnMouseDown()
        {
            Debug.LogError("Called OnMouseDown for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectControl on the first frame that the mouse left clicks up after left clicking down on this object
        *</summary>
        */
        public void OnMouseUp()
        {
            Debug.LogError("Called OnMouseUp for" + this + ";  \n OnMouseUp not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public void OnDeactivate()
        {
            Debug.LogError("Called OnDeactivate for" + this + ";  \n OnDeactivate not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public void OnActivate()
        {
            Debug.LogError("Called OnActivate for" + this + ";  \n OnActivate not implemented");
        }

    }
}

