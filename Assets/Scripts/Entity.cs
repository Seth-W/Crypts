using UnityEngine;
using System;

namespace CFE
{
    class Entity : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<Entity>> entityCreatedEvent;

        public StatBlock stats;
        public int a, s, i;

        void Start()
        {
            stats = new StatBlock(a, s, i);
            entityCreatedEvent(this, new InfoEventArgs<Entity>(this));
        }

        void Update()
        {

        }

        public int rollInitiative()
        {
            int retValue = 0;
            for (int i = 0; i < stats.agility; i++)
            {
                retValue += Mathf.FloorToInt(UnityEngine.Random.value * 2);
            }
            return retValue;
        }

        
    }//End class
}//End namespace