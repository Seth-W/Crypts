using CFE.Commnads.Entities;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(StatBlock))]
    class PlayerEntity : Entity
    {
        public Entity other;

        public override ICommand combatAction()
        {
            ICommand retValue;
            retValue = new AttackCommand(this, other, stats.strength);
            retValue.Exectute();
            Debug.LogError("combatAction not implemented in PlayerEntity");
            return retValue;
        }
        public void click()
        {
            if (_combatActionAvailable)
            {
                combatAction();
                _combatActionAvailable = false;
            }
            Debug.LogWarning("This almost definitely shouldnt happen this way");
        }
    }
}
