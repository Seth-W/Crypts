using UnityEngine;

namespace CFE.Commnads.Entities

{
    class AttackCommand : ICommand
    {
        private EntityModel attacker, defender;
        private int amount;

        public AttackCommand(EntityModel a, EntityModel d, int n)
        {
            attacker = a;
            defender = d;
            amount = n;
        }

        public void Exectute()
        {
            defender.takeDamage(attacker, amount);
        }

        public void Undo()
        {
            Debug.LogError("Undo not implemented in AttackCommand");
        }
    }
}
