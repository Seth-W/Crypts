using System;
using UnityEngine;
using System.Collections.Generic;

namespace CFE
{
    class TurnQueue
    {
        public Entity activeEntity { get { return queue[0].entity; } }
        List<QueueNode> queue;

        public TurnQueue(List<Entity> entities)
        {
            queue = new List<QueueNode>();
            if (entities == null || entities.Count == 0)
            {
                Debug.LogError("Entity List returned NULL");
                return;
            }

            QueueNode n;
            foreach (Entity e in entities)
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
            queue.RemoveAt(0);
        }






        class QueueNode : IComparable
        {
            public int initiative;
            public Entity entity;


            public QueueNode(Entity e, int i)
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
