using UnityEngine;
using System.Collections;

namespace CFE
{
    /**
    *<summary>
    *Base class for the states in the Finite State Machine
    *Contains abstract OnEnter/Exit methods
    *Contains override methods for Equals and GetHashCode
    *</summary>
    */
    abstract class GameState
    {
        protected StateEnum _type;
        protected StateEnum _prevState;
        public StateEnum type { get { return _type; } }
        public StateEnum prevState { get { return prevState; } }

        public abstract void onEnter();
        public abstract void onExit();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            GameState p = obj as GameState;
            if ((System.Object)p == null)
                return false;
            return type == p.type;
        }
        public bool Equals(GameState p)
        {
            if ((object)p == null)
                return false;
            return type == p.type;
        }
        public override int GetHashCode()
        {
            return (int)_type;
        }
        /**
        *<summary>
        *Compares <see cref="type"/> to a StateEnum, <paramref name="other"/>
        *Returns true if type is the same, otherwise returns false
        *</summary>
        */
        public bool compareState(StateEnum other)
        {
            return other == type;
        }
        /**
        *<summary>
        *Compares <see cref="type"/> to the <see cref="type"/> field of another GameState<paramref name="other"/>
        *Returns true if the GameStates type field is the same, otherwise returns false
        *</summary>
        */
        public bool compareState(GameState other)
        {
            return other.type == type;
        }
    }
}
