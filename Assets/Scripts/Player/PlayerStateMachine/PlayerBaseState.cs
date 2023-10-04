using UnityEngine;

namespace PlayerStateMachine
{
    // This is the base of the finite state machine
    public abstract class PlayerBaseState
    {

        protected PlayerStatesManager m_context;
        protected PlayerStateFactory m_factory;

        public PlayerBaseState(PlayerStatesManager context, PlayerStateFactory factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void ExitState();
        public abstract void CheckSwitchState();

    }
}
