using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Contains the simulation information for an ActionButton
    *</summary>
    */
    class ActionButtonModel : ObjectModel
    {
        [SerializeField]
        int abilityThisButtonRepresents;
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                          Debug Code                           |
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        [SerializeField]
        PlayerEntityModel actor, target;
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //                          Debug Code                           |
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public AbilityMasterList AbilityMasterList;

        ActionButtonControl control;

        public delegate void OnDeactivate();
        public delegate void OnActivate();
        public event OnDeactivate ActionButtonActivateEvent;
        public event OnActivate ActionButtonDeactivateEvent;

        void OnEnable()
        {
            control = GetComponent<ActionButtonControl>();
            //Null Test
            if (control == null)
            {
                Debug.LogError("Could not find an IObjectControl on " + gameObject);
                return;
            }
            //Subscribe to Control OnMouseUp/Down events
            control.ActionButtonMouseUpEvent += OnPrimaryMouseUp;

        }

        void OnDisable()
        {
            control.ActionButtonMouseUpEvent -= OnPrimaryMouseUp;
        }

        /**
        *<summary>
        *Responds to control.ActionButtonMouseUpEvent
        *</summary>
        */
        private void OnPrimaryMouseUp()
        {
            AbilityMasterList.spellBook[getAbilityForThisButton()](actor, target).Exectute();
            Debug.LogWarning("Called OnMouseUp for " + this + "\n OnMouseUp not implemented");
        }


        /**
        *<summary>
        *Responds to ObjectModel.active = false
        *</summary>
        */
        public override void Deactivate()
        {
            //Debug.Log("Called Deactivate for " + this);
            if(ActionButtonActivateEvent != null)
                ActionButtonActivateEvent();
        }

        /**
        *<summary>
        *Responds to ObjectModel.active = true
        *</summary>
        */
        public override void Activate()
        {
            //Debug.Log("Called Enable for " + this);
            if (ActionButtonDeactivateEvent != null)
                ActionButtonDeactivateEvent();
        }
        /**
        *<summary>
        *Gets an ability Enum from the active entity representing the ability for this button to control
        *</summary>
        */
        public EntityAbilityEnum getAbilityForThisButton()
        {
            return TurnQueueManager.activeEntity.getAbility(abilityThisButtonRepresents);
        }
    }
}
