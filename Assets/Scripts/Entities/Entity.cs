using UnityEngine;
using System;

namespace CFE
{
    abstract class Entity : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<Entity>> entityCreatedEvent;

        public StatBlock stats;

        protected bool combatActionAvailable;

        void Start()
        {
            entityCreatedEvent(this, new InfoEventArgs<Entity>(this));
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
            combatActionAvailable = true;
        }

        public virtual void takeDamage(Entity attacker, int n)
        {
            Debug.Log("Took " + n + " damage from " + attacker);
            Debug.LogError("Default take damage not implemented");
        }

        public abstract ICommand combatAction();

        private void OnNewTurnEvent(object sender, InfoEventArgs<Entity> e)
        {
            if (e.info != this)
                return;
            else
                resetActions();
        }

    }//End class
}//End namespace