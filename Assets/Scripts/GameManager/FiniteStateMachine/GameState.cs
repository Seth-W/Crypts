using UnityEngine;
using System.Collections;

namespace CFE
{
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

        public bool compareState(StateEnum other)
        {
            return other == type;
        }
    }
}
