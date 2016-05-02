using UnityEngine;
using System.Collections.Generic;

namespace CFE
{
    class FiniteStateMachine : MonoBehaviour
    {
        public static FiniteStateMachine singleton;

        private State _activeState;
        public State activeState
        {
            get { return activeState; }
            set { transition(value); }
        }
        private bool _inTransition;
        private Dictionary<StateEnum, State> stateList;

        void Start()
        {
            initAsUnique();
            init();
        }
        /**
        *<summary>Call to transition from State to state. Checks if already in transition and calls the OnEnter and OnExit methods for the respective states</summary>
        */
        void transition(State targetState)
        {
            if (_inTransition == true)
                return;
            _inTransition = true;
            _activeState.onExit();
            _activeState = targetState;
            _activeState.onEnter();
            _inTransition = false;
        }
        /**
        *<summary>Checks if another FSM exists in the scene and deletes this object if so</summary>
        */
        void initAsUnique()
        {
            if (singleton == null)
                singleton = this;
            else
                Destroy(this);
        }
        /**
        *<summary>Initializes the values in the Finite State Machine</summary>
        */
        void init()
        {
            _inTransition = false;
        }
        void populateStates()
        { }
    }
}