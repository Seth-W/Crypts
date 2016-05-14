using UnityEngine;
using System;

namespace CFE
{
    /**
    *<summary>
    *Handles OnEnter and OnExit events and behavior for the finite state machine
    *</summary>
    */
    class CombatState : GameState
    {
        public static event EventHandler<InfoEventArgs<int>> combatEnterEvent;

        //Constructor
        public CombatState()
        {
            _type = StateEnum.CombatState;
        }

        public override void onEnter()
        {
            combatEnterEvent(this, new InfoEventArgs<int>(0));
            //Debug.LogError("OnEnter called for " + this + "\nNot implemented");
        }

        public override void onExit()
        {
            //Debug.LogError("OnExit called for " + this + "\nNot implemented");
        }
    }
}
