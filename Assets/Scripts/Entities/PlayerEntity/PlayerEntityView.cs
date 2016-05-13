using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Controls the visual behavior of a Player Piece
    *Responds to calls from an ObjectControl componenent for HoverOn/Off & MouseUp/Down
    *Responds to calls from an ObjectModel component for Enable/Disable
    *</summary>
    */
    class PlayerEntityView : MonoBehaviour, IObjectView
    {
        PlayerEntityControl control;
        PlayerEntityModel model;

        void OnEnable()
        {
            //Gets PlayerEntityControl componenet from Gameobjec
            //exits early and throws error if not found
            control = GetComponent<PlayerEntityControl>();
            if (control == null)
            {
                Debug.LogError("Could not find a PlayerEntityControl on " + gameObject);
                return;
            }
            //Gets PlayerEntityModel component form gameObject
            //exits early and throws error if not found
            model = GetComponent<PlayerEntityModel>();
            if (control == null)
            {
                Debug.LogError("Could not find a PlayerEntityModel on " + gameObject);
                return;
            }


            //Subscribe to PlayerEntityControl events
            control.PlayerEntityHoverOffEvent += OnHoverOff;
            control.PlayerEntityHoverOnEvent += OnHoverOn;
            control.PlayerEntityMouseDownEvent += OnMouseDown;
            control.PlayerEntityMouseUpEvent += OnMouseUp;
            //Subscribe to PlayerEnttiyModel events
            model.PlayerEntityActivateEvent += OnActivate;
            model.PlayerEntityDeactivateEvent += OnDeactivate;
        }

        void OnDisable()
        {
            //Unsubscribe to PlayerEntityControl events
            control.PlayerEntityHoverOffEvent -= OnHoverOff;
            control.PlayerEntityHoverOnEvent -= OnHoverOn;
            control.PlayerEntityMouseDownEvent -= OnMouseDown;
            control.PlayerEntityMouseUpEvent -= OnMouseUp;
            //Unsubscribe to PlayerEnttiyModel events
            model.PlayerEntityActivateEvent -= OnActivate;
            model.PlayerEntityDeactivateEvent -= OnDeactivate;
        }
        
        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse hovers over this gameObject
        *</summary>
        */
        public void OnHoverOn()
        {
            Debug.LogError("Called OnHoverOn for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by an ObjectControl on the first frame that the mouse is no longer hovering over this gameObject when it previously had been
        *</summary>
        */
        public void OnHoverOff()
        {
            Debug.LogError("Called OnHoverOff for" + this + ";  \n OnMouseDown not implemented");
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
            Debug.LogError("Called OnMouseUp for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public void OnActivate()
        {
            Debug.LogError("Called OnEnable for" + this + ";  \n OnMouseDown not implemented");
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public void OnDeactivate()
        {
            Debug.LogError("Called OnDisable for" + this + ";  \n OnMouseDown not implemented");
        }
    }
}
