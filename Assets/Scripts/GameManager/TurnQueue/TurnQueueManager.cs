using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Component responsible for storing a <see cref="TurnQueue"/> object
    *Keeps the master list of entities involved in an egagement
    *Responds to <see cref="EntityModel.newEntityEvent"/>
    *</summary>
    */
    class TurnQueueManager : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> endTurnEvent;
        public static EntityModel activeEntity;

        //Master entity list for an egagement
        List<EntityModel> entities;
        //Initiative order for an egagement
        TurnQueue queue;

        void OnEnable()
        {
            //Subscribe to events
            EntityModel.newEntityEvent += onNewEntityEvent;
        }

        void OnDisable()
        {
            //Unsubscribe to events
            EntityModel.newEntityEvent -= onNewEntityEvent;
        }


        void Start()
        {
            //Inititialize the master list of entities
            entities = new List<EntityModel>();

            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Debug.LogWarning("Don't Forget to hit enter to initialize a turn queue");
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        void Update()
        {
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rollInitiative();
                Debug.LogWarning("Don't forget to remove me");
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
        
        /**
        *<summary>
        *Creates a new <see cref="TurnQueue"/> from the stored <see cref="entities"/> property
        *Called on new engagement events
        *</summary>
        */
        private void rollInitiative()
        {
            queue = new TurnQueue(entities);
            activeEntity = queue.activeEntity;
        }

        /**
        *<summary>
        *Responds to <see cref="EntityModel.newEntityEvent"/> and adds the sender to the entity master list
        *</summary>
        */
        private void onNewEntityEvent(EntityModel model)
        {
            entities.Add(model);
        }

        /**
        *<summary>
        *Responds to <see cref="EndTurnButtonControl.endTurnButtonPressedEvent"/>
        *Updates the stored turnqueue to the next turn
        *Calls a general EndTurnEvent
        *</summary>
        */
        private void OnEndTurnButtonPressedEvent(object sender, InfoEventArgs<bool> e)
        {
            queue.endTurn();
            activeEntity = queue.activeEntity;
            endTurnEvent(this, new InfoEventArgs<EntityModel>(queue.activeEntity));
        }

    }
}
