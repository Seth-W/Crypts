using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueueManager : MonoBehaviour
    {
        EntityModel activeEntity { get { return queue.activeEntity; } }
        List<EntityModel> entities;
        TurnQueue queue;

        void OnEnable()
        {
            EntityModel.newEntityEvent += onNewEntityEvent;
        }

        void OnDisable()
        {
            EntityModel.newEntityEvent -= onNewEntityEvent;
        }

        void Start()
        {
            entities = new List<EntityModel>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                rollInitiative();
        }

        private void rollInitiative()
        {
            queue = new TurnQueue(entities);
        }

        private void onNewEntityEvent(object sender, InfoEventArgs<EntityModel> e)
        {
            entities.Add(e.info);
        }

    }
}
