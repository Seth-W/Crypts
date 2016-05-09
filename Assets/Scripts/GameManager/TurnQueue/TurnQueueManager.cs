using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueueManager : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> newTurnEvent;

        public static EntityModel activeEntity;
        public TurnQueue queue;

        public EntityModel a, b, c;
        List<EntityModel> entities;

        void Start()
        {
            entities = new List<EntityModel>();
        }

        void OnEnable()
        {
            EntityModel.entityCreatedEvent += OnEntityCreatedEvent;
            CombatState.combatEnterEvent += OnCombatEnterEvent;
        }
        void OnDisable()
        {
            EntityModel.entityCreatedEvent -= OnEntityCreatedEvent;
            CombatState.combatEnterEvent -= OnCombatEnterEvent;
        }

        void Update()
        {

        }

        private void rollInitiative()
        {
            queue = new TurnQueue(entities);
            activeEntity = queue.activeEntity;
            Debug.Log(activeEntity.actionAvailable);
        }

        private void nextTurn()
        {
            queue.nextTurn();
            newTurnEvent(this, new InfoEventArgs<EntityModel>(activeEntity));
        }


        private void OnEntityCreatedEvent(object sender, InfoEventArgs<EntityModel> e)
        {
            entities.Add(e.info);
        }

        private void OnCombatEnterEvent(object sender, InfoEventArgs<int> e)
        {
            rollInitiative();
        }
    }
}
