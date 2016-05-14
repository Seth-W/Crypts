using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the simulation information for an EndTurnButton
    *</summary>
    */
    class EndTurnButtonModel : ObjectModel
    {
        EndTurnButtonControl control;

        public delegate void OnDeactivate();
        public delegate void OnActivate();
        public event OnDeactivate EndTurnButtonActivateEvent;
        public event OnActivate EndTurnButtonDeactivateEvent;

        void OnEnable()
        {
            control = GetComponent<EndTurnButtonControl>();
            //Null Test
            if (control == null)
            {
                Debug.LogError("Could not find an IObjectControl on " + gameObject);
                return;
            }
            //Subscribe to Control OnMouseUp/Down events
            control.EndTurnButtonMouseUpEvent += OnMouseUp;

        }

        void OnDisable()
        {
            control.EndTurnButtonMouseUpEvent -= OnMouseUp;
        }


        public void Start()
        {
            active = false;
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to true
        *</summary>
        */
        public override void Activate()
        {

        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public override void Deactivate()
        {

        }

        /**
        *<summary>
        *Responds to control.ActionButtonMouseUpEvent
        *</summary>
        */
        private void OnMouseUp()
        {
            Debug.LogWarning("Called OnMouseUp for " + this + "\n OnMouseUp not implemented");
        }
    }
}
