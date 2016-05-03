using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueueManager : MonoBehaviour
    {
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
        }
        void OnDisable()
        {
            Entity.entityCreatedEvent -= OnEntityCreatedEvent;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
                queue = new TurnQueue(entities);
        }

        private void rollInitiative()
        {
            queue = new TurnQueue(entities);
            activeEntity = queue.activeEntity;
        }

        private void OnEntityCreatedEvent(object sender, InfoEventArgs<Entity> e)
        {
            entities.Add(e.info);
        }
    }
}
