using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *Stores an ordered list of Entities
    *Allows for Ordered queuing through the list
    *Created by TurnQueueManager component on CombatEnter Events
    *</summary>
    */
    class TurnQueue
    {
        public EntityModel activeEntity { get { return initiativeOrder[0].entity; } }
        List<QueueNode> initiativeOrder;

        //Constructor
        public TurnQueue(List<EntityModel> entities)
        {
            //Null test
            if (entities == null)
            {
                Debug.LogError("Entity List is NULL");
                return;
            }
            //Initialize the List
            initiativeOrder = new List<QueueNode>();
            
            //Create a queuenode for each entity with a call to roll initiative
            foreach (EntityModel e in entities)
            {
                initiativeOrder.Add(new QueueNode(e, e.rollInitiative() ) );
            }
            
            //Sort the list based on the initiative value stored in the QueueNodes
            initiativeOrder.Sort();

            //Debug.Log(initiativeOrder.Count + " # of items in Initiative order");

            foreach (QueueNode n in initiativeOrder)
            {
                Debug.Log(n.entity + ": " + n.initiative);
            }
        }

        public void endTurn()
        {
            //Null test
            if (initiativeOrder == null)
            {
                Debug.LogError("The initiative order list was never initialized or has been deleted");
                return;
            }
            //Test if the list is empty
            if (initiativeOrder.Count == 0)
            {
                Debug.LogError("No entities present in TurnQueue");
                return;
            }
            //Adds the first item in the initiative order to the end of the list
            //Then removes it from the front
            initiativeOrder.Add(initiativeOrder[0]);
            initiativeOrder.RemoveAt(0);
        }


        /*
        *Inner class responsible for storing an entity and an initiative value
        *Implements IComporable
        */
        class QueueNode : IComparable
        {
            private EntityModel _entity;
            private int _initiative;
            public EntityModel entity { get { return _entity; } }
            public int initiative { get { return _initiative; } }

            //Constructor
            public QueueNode(EntityModel e, int i)
            {
                _entity = e;
                _initiative = i;
            }

            public int CompareTo(object obj)
            {
                QueueNode other = obj as QueueNode;
                //Null test
                if (other == null)
                {
                    Debug.LogError("Object isn't of type QueueNode");
                    return 0;
                }
                return other._initiative - _initiative;
            }
        }
    }
}
