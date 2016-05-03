using UnityEngine;
using System;

namespace CFE
{
    class CombatState : GameState
    {
        public static event EventHandler<InfoEventArgs<Entity>> OnCombatEnterEvent;

        public CombatState()
        {
            _type = StateEnum.CombatState;
        }

        public override void onEnter()
        {
            //OnCombatEnterEvent(this, )
            Debug.LogError("Not implemented");
        }

        public override void onExit()
        {
            Debug.LogError("Not implemented");
        }
    }
}
