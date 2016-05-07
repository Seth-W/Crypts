using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(PrimaryAttackButtonView))]
    [RequireComponent(typeof(PrimaryAttackButtonControl))]
    class PrimaryAttackButtonModel : ActionButtonModel
    {

        public override bool isAvailable()
        {
            return TurnQueueManager.activeEntity.combatActionAvailable;
        }
    }
}
