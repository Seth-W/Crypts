using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace CFE
{
    class AbilityBook 
    {

        public delegate ICommand Ability(EntityModel actor, EntityModel target);

        public Dictionary<EntityAbilityEnum,Ability>  spellBook;


        public AbilityBook()
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
