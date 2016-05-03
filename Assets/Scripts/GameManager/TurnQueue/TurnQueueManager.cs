using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueueManager : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<Entity>> newTurnEvent;

        public static Entity activeEntity;
        public TurnQueue queue;

        public Entity a, b, c;
        List<Entity> entities;

        void Start()
        {
            entities = new List<Entity>();
        }

        void OnEnable()
        {
            Entity.entityCreatedEvent += OnEntityCreatedEvent;
            CombatState.combatEnterEvent += OnCombatEnterEvent;
        }
        void OnDisable()
        {
            Entity.entityCreatedEvent -= OnEntityCreatedEvent;
            CombatState.combatEnterEvent -= OnCombatEnterEvent;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                queue = new TurnQueue(entities);
        }

        private void rollInitiative()
        {
            queue = new TurnQueue(entities);
            activeEntity = queue.activeEntity;
        }

        private void nextTurn()
        {
            queue.nextTurn();
            newTurnEvent(this, new InfoEventArgs<Entity>(activeEntity));
        }


        private void OnEntityCreatedEvent(object sender, InfoEventArgs<Entity> e)
        {
            entities.Add(e.info);
        }

        private void OnCombatEnterEvent(object sender, InfoEventArgs<int> e)
        {
            rollInitiative();
        }
    }
}
