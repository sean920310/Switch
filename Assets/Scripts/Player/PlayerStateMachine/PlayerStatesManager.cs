using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStateMachine
{
    public class PlayerStatesManager : MonoBehaviour
    {
        PlayerBaseState _currentState = null;

        PlayerStateFactory _factory = null;
        public PlayerStateFactory Factory { get => _factory; set => _factory = value; }

        private void Start()
        {
            // get game component


            // state setup
            _factory = new PlayerStateFactory(this);
            _currentState = Factory.Idle(); // Initial State
            _currentState.EnterState();

            // variable initialize

        }
        private void Update()
        {
            _currentState.UpdateState();
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdateState();
        }

        public void SwitchState(PlayerBaseState newState)
        {
            _currentState.ExitState();

            newState.EnterState();

            this._currentState = newState;
        }
    }
}
