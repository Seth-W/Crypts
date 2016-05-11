using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueueManager : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> endTurnEvent;
        EntityModel activeEntity { get { return queue.activeEntity; } }
        List<EntityModel> entities;
        TurnQueue queue;

        void OnEnable()
        {
            EntityModel.newEntityEvent += onNewEntityEvent;
            EndTurnButtonControl.endTurnButtonPressedEvent += OnEndTurnButtonPressedEvent;
        }

        void OnDisable()
        {
            EntityModel.newEntityEvent -= onNewEntityEvent;
            EndTurnButtonControl.endTurnButtonPressedEvent -= OnEndTurnButtonPressedEvent;
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

        private void OnEndTurnButtonPressedEvent(object sender, InfoEventArgs<bool> e)
        {
            queue.endTurn();
            endTurnEvent(this, new InfoEventArgs<EntityModel>(activeEntity));
        }

    }
}
