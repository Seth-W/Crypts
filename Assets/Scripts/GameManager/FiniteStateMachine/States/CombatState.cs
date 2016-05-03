using UnityEngine;
using System;

namespace CFE
{
    class CombatState : GameState
    {
        public static event EventHandler<InfoEventArgs<int>> combatEnterEvent;

        public CombatState()
        {
            _type = StateEnum.CombatState;
        }

        public override void onEnter()
        {
            combatEnterEvent(this, new InfoEventArgs<int>(0));
            Debug.LogError("Not implemented");
        }

        public override void onExit()
        {
            Debug.LogError("Not implemented");
        }
    }
}
