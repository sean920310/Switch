using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            _context = context;
            _factory = factory;
        }

        public override void EnterState()
        {

        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {

        }

        public override void CheckSwitchState()
        {

        }
    }
}
