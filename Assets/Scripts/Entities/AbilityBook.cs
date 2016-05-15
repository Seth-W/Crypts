using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CFE
{
    [CreateAssetMenu(fileName =  "Ability Book", menuName = "Scriptable Objects/Ability Book", order = 0)]
    class AbilityBook  : ScriptableObject
    {

        public delegate ICommand Ability(EntityModel actor, EntityModel target);

        public Dictionary<EntityAbilityEnum,Ability>  spellBook;


        public void init()
        {
            spellBook = new Dictionary<EntityAbilityEnum, Ability>();
            spellBook.Add(EntityAbilityEnum.Attack, attack);
            spellBook.Add(EntityAbilityEnum.Heal, heal);
        }

        public ICommand attack(EntityModel actor, EntityModel target)
        {
            return new AttackCommand(actor, target);
        }

        public ICommand heal(EntityModel actor, EntityModel target)
        {
            return new HealCommand(actor, target);
        }
    }
}
