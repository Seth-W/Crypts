using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the visual behavior for an EndTurnButton
    *</summary>
    */
    class EndTurnButtonView : ButtonView3D
    {
        Renderer rend;

        EndTurnButtonControl control;
        EndTurnButtonModel model;

        public override void OnEnable()
        {
            base.OnEnable();

            control = GetComponent<EndTurnButtonControl>();
            if(control == null)
            {
                Debug.LogWarning("Could not find an IObjectControl componenet on " + gameObject);
                return;
            }

            model = GetComponent<EndTurnButtonModel>();
            if(model == null)
            {
                Debug.LogWarning("Could not find an IObjectModel componenet on " + gameObject);
                return;
            }

            //Subscribing to the control events
            control.EndTurnButtonHoverOffEvent += OnHoverOff;
            control.EndTurnButtonHoverOnEvent += OnHoverOn;
            control.EndTurnButtonMouseDownEvent += OnMouseDown;
            control.EndTurnButtonMouseDownRevertEvent += OnMouseDownRevert;
            control.EndTurnButtonMouseUpEvent += OnMouseUp;
            //Subscribing to the model events
            model.EndTurnButtonActivateEvent += OnActivate;
            model.EndTurnButtonDeactivateEvent += OnDeactivate;
        }



        void Start()
        {
            rend = GetComponent<Renderer>();
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            rend.material.color = Color.yellow;
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public override void OnActivate()
        {
            base.OnActivate();
            rend.material.color = Color.green;
        }
    }
}
