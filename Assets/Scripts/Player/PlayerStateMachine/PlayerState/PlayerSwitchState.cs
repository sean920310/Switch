using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerSwitchState : PlayerBaseState
    {
        public PlayerSwitchState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            if (m_context.dimension == CameraManager.Dimension.TwoD)
            {
                //To 2D
                m_context.rb.gravityScale = 1f;
            }
            else
            {
                //To 3D
                m_context.canAttack = false;
                m_context.rb.gravityScale = 0;
            }
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
            m_context.SwitchState(m_factory.Idle());
        }
    }
}
