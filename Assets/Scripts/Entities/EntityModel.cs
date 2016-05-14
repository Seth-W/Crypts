using System;
using UnityEngine;

namespace CFE
{
    abstract class EntityModel : ObjectModel
    {
        public delegate void NewEntity(EntityModel newEntity);
        public static event NewEntity newEntityEvent;

        StatBlock stats;

        //Editor defined values to initialize stats
        [SerializeField]
        int a, s, i, diceValue;

        public int agility { get { return stats.agility; } }
        public int strength { get { return stats.strength; } }
        public int intelligence { get { return stats.intelligence; } }


        public void Start()
        {
            //Initialize the stats
            stats = new StatBlock(a, s, i);
            //Send a newEntity event
            newEntityEvent(this);
        }

        /**
        *<summary>
        *Returns the sum of a series of dice rolls
        *The number of dice rolled is determined by the entity's agility
        *The sides of the dice is determined by an editor defined field
        *</summary>
        */
        public int rollInitiative()
        {
            int retValue = 0;
            for (int i = 0; i < agility; i++)
            {
                retValue += Mathf.FloorToInt(UnityEngine.Random.value * diceValue);
            }
            return retValue;
        }
    }
}
