using System;
using UnityEngine;

namespace CFE
{
    abstract class EntityModel : ObjectModel
    {
        public static event EventHandler<InfoEventArgs<EntityModel>> newEntityEvent;
        StatBlock stats;
        [SerializeField]
        int a, s, i;

        public int agility { get { return stats.agility; } }
        public int strength { get { return stats.strength; } }
        public int intelligence { get { return stats.intelligence; } }


        public override void Start()
        {
            base.Start();
            stats = new StatBlock(a, s, i);
            newEntityEvent(this, new InfoEventArgs<EntityModel>(this));
        }

        public int rollInitiative()
        {
            int retValue = 0;
            for (int i = 0; i < agility; i++)
            {
                retValue += Mathf.FloorToInt(UnityEngine.Random.value * 6);
            }
            return retValue;
        }
    }
}
