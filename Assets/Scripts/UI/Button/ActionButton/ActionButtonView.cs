using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the visual behavior for an ActionButton
    *</summary>
    */
    class ActionButtonView : ButtonView3D
    {
        Renderer rend;

        ActionButtonControl control;
        ActionButtonModel model;

        public override void OnEnable()
        {
            base.OnEnable();

            control = GetComponent<ActionButtonControl>();
            if (control == null)
            {
                Debug.LogWarning("Could not find an IObjectControl componenet on " + gameObject);
                return;
            }

            model = GetComponent<ActionButtonModel>();
            if (model == null)
            {
                Debug.LogWarning("Could not find an IObjectModel componenet on " + gameObject);
                return;
            }

            //Subscribing to the control events
            control.ActionButtonHoverOffEvent += OnHoverOff;
            control.ActionButtonHoverOnEvent += OnHoverOn;
            control.ActionButtonMouseDownEvent += OnPrimaryMouseDown;
            control.ActionButtonMouseDownRevertEvent += OnPrimaryMouseDownRevert;
            control.ActionButtonMouseUpEvent += OnPrimaryMouseUp;
            //Subscribing to the model events
            model.ActionButtonActivateEvent += OnActivate;
            model.ActionButtonDeactivateEvent += OnDeactivate;
        }

        public override void OnDisable()
        {
            base.OnDisable();

            //Subscribing to the control events
            control.ActionButtonHoverOffEvent -= OnHoverOff;
            control.ActionButtonHoverOnEvent -= OnHoverOn;
            control.ActionButtonMouseDownEvent -= OnPrimaryMouseDown;
            control.ActionButtonMouseDownRevertEvent -= OnPrimaryMouseDownRevert;
            control.ActionButtonMouseUpEvent -= OnPrimaryMouseUp;
            //Subscribing to the model events
            model.ActionButtonActivateEvent -= OnActivate;
            model.ActionButtonDeactivateEvent -= OnDeactivate;
        }
    }
}
