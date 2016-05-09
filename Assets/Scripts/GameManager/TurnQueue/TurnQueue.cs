using System;
using System.Collections.Generic;
using UnityEngine;

namespace CFE
{
    class TurnQueue
    {
        public EntityModel activeEntity { get { return initiativeOrder[0].entity; } }
        List<QueueNode> initiativeOrder;


        public TurnQueue(List<EntityModel> entities)
        {
            if (entities == null)
            {
                Debug.LogError("Entity List is NULL");
                return;
            }
            initiativeOrder = new List<QueueNode>();
            foreach (EntityModel e in entities)
            {
                initiativeOrder.Add(new QueueNode(e, e.rollInitiative() ) );
            }
            initiativeOrder.Sort();
            foreach (QueueNode n in initiativeOrder)
            {
                Debug.Log(n.entity + ": " + n.initiative);
            }
        }

        class QueueNode : IComparable
        {
            private EntityModel _entity;
            private int _initiative;
            public EntityModel entity { get { return _entity; } }
            public int initiative { get { return _initiative; } }

            public QueueNode(EntityModel e, int i)
            {
                _entity = e;
                _initiative = i;
            }

            public int CompareTo(object obj)
            {
                QueueNode other = obj as QueueNode;
                if(other == null)//NullCheck
                {
                    Debug.LogError("Object isn't of type QueueNode");
                    return 0;
                }
                return other._initiative - _initiative;
            }
        }
    }
}
