using UnityEngine;
using System;

namespace CFE
{
    abstract class EntityModel : ObjectModel
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> entityCreatedEvent;

        public StatBlock stats;

        protected bool _combatActionAvailable;
        protected bool _maneuverActionAvailable;

        public bool actionAvailable
        {
            get { return _combatActionAvailable || _maneuverActionAvailable; }
        }
        public bool combatActionAvailable
        { get { return _combatActionAvailable; } }
        public bool maneuverActionAvailabe
        { get { return _maneuverActionAvailable; } }

        void Start()
        {
            entityCreatedEvent(this, new InfoEventArgs<EntityModel>(this));
            resetActions();
        }

        void Update()
        {

        }

        void OnEnable()
        {
            TurnQueueManager.newTurnEvent += OnNewTurnEvent;
        }

        void OnDisable()
        {
            TurnQueueManager.newTurnEvent -= OnNewTurnEvent;
        }

        public int rollInitiative()
        {
            int retValue = 0;
            for (int i = 0; i < stats.agility; i++)
            {
                retValue += Mathf.FloorToInt(UnityEngine.Random.value * 2);
            }
            return retValue;
        }

        private void resetActions()
        {
            _combatActionAvailable = true;
            Debug.LogWarning("ManeuverAction Not implemented. Does not reset.");
            _maneuverActionAvailable = false;
        }

        public virtual void takeDamage(EntityModel attacker, int n)
        {
            Debug.Log("Took " + n + " damage from " + attacker);
            Debug.LogError("Default take damage not implemented");
        }

        public abstract ICommand combatAction();

        private void OnNewTurnEvent(object sender, InfoEventArgs<EntityModel> e)
        {
            if (e.info != this)
                return;
            else
                resetActions();
        }

    }//End class
}//End namespace