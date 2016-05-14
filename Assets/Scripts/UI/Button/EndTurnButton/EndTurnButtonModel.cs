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
            control.EndTurnButtonMouseUpEvent += OnPrimaryMouseUp;

        }

        void OnDisable()
        {
            control.EndTurnButtonMouseUpEvent -= OnPrimaryMouseUp;
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
            Debug.Log("Activate Called for " + this);
            if (EndTurnButtonActivateEvent != null)
                EndTurnButtonActivateEvent();
        }

        /**
        *<summary>
        *Called by and ObjectModel when the objectModel Enabled property is set to false
        *</summary>
        */
        public override void Deactivate()
        {
            if (EndTurnButtonDeactivateEvent != null)
                EndTurnButtonDeactivateEvent();
        }

        /**
        *<summary>
        *Responds to control.ActionButtonMouseUpEvent
        *</summary>
        */
        private void OnPrimaryMouseUp()
        {
            Debug.LogWarning("Called OnMouseUp for " + this + "'s Model\n OnMouseUp not implemented");
        }
    }
}
