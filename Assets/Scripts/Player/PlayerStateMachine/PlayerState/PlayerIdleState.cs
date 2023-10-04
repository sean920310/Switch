using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerIdleState : PlayerBaseState
    {
        public PlayerIdleState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            if(m_context.moveValue.x == 0f)
            {
                m_context.rb.velocity = new Vector3(0f, m_context.rb.velocity.y, m_context.rb.velocity.z);
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
            if (m_context.moveValue.x != 0f)
                m_context.SwitchState(m_factory.Walk());
            else if (m_context.desireToJump && m_context.CanJump())
            {
                m_context.SwitchState(m_factory.Jump());
            }
        }
    }
}
