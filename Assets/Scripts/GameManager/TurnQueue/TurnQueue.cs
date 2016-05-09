using System;
using UnityEngine;
using System.Collections.Generic;

namespace CFE
{
    class TurnQueue
    {
        public EntityModel activeEntity { get { return queue[0].entity; } }
        List<QueueNode> queue;

        public TurnQueue(List<EntityModel> entities)
        {
            queue = new List<QueueNode>();
            if (entities == null || entities.Count == 0)
            {
                Debug.LogError("Entity List returned NULL");
                return;
            }

            QueueNode n;
            foreach (EntityModel e in entities)
            {
                n = new QueueNode(e, e.rollInitiative());
                queue.Add(n);
            }
            queue.Sort();

            foreach(QueueNode q in queue)
            {
                Debug.Log(q.entity + " rolled " + q.initiative);
            }
        }

        public void nextTurn()
        {
            queue.Add(queue[0]);
            queue.RemoveAt(0);
        }






        class QueueNode : IComparable
        {
            public int initiative;
            public EntityModel entity;


            public QueueNode(EntityModel e, int i)
            {
                entity = e;
                initiative = i;
            }

            public int CompareTo(object obj)
            {
                if (obj == null)
                    return 1;
                QueueNode other = obj as QueueNode;
                if (other != null)
                    return other.initiative.CompareTo(initiative);
                else
                    throw new ArgumentException("Object is not a QueueNode");
            }
        }//End of QueueNode Inner Class
    }
}
