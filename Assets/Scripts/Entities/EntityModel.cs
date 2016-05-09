using UnityEngine;
using System;

namespace CFE
{
    abstract class EntityModel : ObjectModel
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> newEntityEvent;

        StatBlock stats;
        public int agility { get { return stats.agility; } }
        public int strength { get { return stats.strength; } }
        public int intelligence { get { return stats.intelligence; } }
        public int a, s, i;

        void Start()
        {
            stats = new StatBlock(a, s, i);
            newEntityEvent(this, new InfoEventArgs<EntityModel>(this));
        }

        public int rollInitiative()
        {
            int retValue = 0;
            for (int i = 0; i < intelligence; i++)
                retValue += Mathf.CeilToInt(UnityEngine.Random.value * 6);
            return retValue;
        }
    }
}
