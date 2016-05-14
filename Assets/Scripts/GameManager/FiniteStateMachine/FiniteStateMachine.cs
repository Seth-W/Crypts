using UnityEngine;
using System.Collections.Generic;

namespace CFE
{
    class FiniteStateMachine : MonoBehaviour
    {
        public static FiniteStateMachine singleton;

        private GameState _activeState;
        public GameState activeState
        {
            get { return activeState; }
            set { transition(value); }
        }
        private bool _inTransition;
        private Dictionary<StateEnum, GameState> states;

        void Start()
        {
            initAsUnique();
            init();
        }

        void Update()
        {
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            if (Input.GetKeyDown(KeyCode.Return))
            {
                transition(StateEnum.CombatState);
                Debug.LogError("Don't Forget to Remove Me");
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //                          Debug Code                           |
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }




        /**
        *<summary>
        *Call to transition from State to state. 
        *Checks if already in transition and calls the OnEnter and OnExit methods for the respective states
        *</summary>
        */
        void transition(GameState targetState)
        {
            //If already being called to transition, return
            if (_inTransition == true)
                return;
            //Store transition starting
            _inTransition = true;
            //Call onExit for current state, update activeState and call OnEnter
            _activeState.onExit();
            _activeState = targetState;
            _activeState.onEnter();
            //Store end of transtition
            _inTransition = false;
        }

        /**
        *<summary>
        *Overload of transition to take <see cref="StateEnum"/>
        *<seealso cref="transition(GameState)"/>
        *</summary>
        */
        void transition(StateEnum targetState)
        {
            GameState state = states[targetState];
            if (state != null)
            {
                transition(state);
            }
            else
            {
                Debug.LogError("Target enum: " + targetState + " was not in the state list");
            }
        }
            


        /**
        *<summary>
        *Checks if another FSM exists in the scene and deletes this object if so
        *</summary>
        */
        void initAsUnique()
        {
            if (singleton == null)
                singleton = this;
            else
                Destroy(this);
        }
        /**
        *<summary>
        *Initializes the values in the Finite State Machine
        *</summary>
        */
        void init()
        {
            _inTransition = false;
            populateStates();
        }
        /**
        *<summary>
        *Called (by <see cref="init"/>) during Start to populate the <see cref="states"/> dictionary
        *</summary>
        */
        void populateStates()
        {
            states = new Dictionary<StateEnum, GameState>();
            states.Add(StateEnum.CombatState, new CombatState());


            _activeState = states[StateEnum.CombatState];
        }
    }
}