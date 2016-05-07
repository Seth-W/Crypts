using UnityEngine;

namespace CFE.Commnads.Entities

{
    class AttackCommand : ICommand
    {
        private Entity attacker, defender;
        private int amount;

        public AttackCommand(Entity a, Entity d, int n)
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
