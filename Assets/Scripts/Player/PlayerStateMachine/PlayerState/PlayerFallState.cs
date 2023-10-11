using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerFallState : PlayerBaseState
    {
        public PlayerFallState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
        
        }

        public override void UpdateState()
        {
            // _context.rb.gravityScale = _context.FallGravityScale;

            // air control
            if(m_context.moveValue != Vector2.zero)
            {
                if (m_context.moveValue.x < 0f)
                {
                    m_context.FacingLeft();
                }
                else if (m_context.moveValue.x > 0f)
                {
                    m_context.FacingRight();
                }
            }

            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            m_context.MoveWithLimit(m_context.moveValue * m_context.playerAirMoveSpeedX, m_context.playerAirMaxSpeedX);
        }

        public override void ExitState()
        {
        
        }

        public override void CheckSwitchState()
        {
            if (m_context.CheckOnFloor())
            {
                m_context.jumpCounts = m_context.maxJumpCount; // Jump Counts Reloading
                m_context.SwitchState(m_factory.Idle());
            }
            else if (m_context.desireToJump && m_context.CanJump())
            {
                m_context.SwitchState(m_factory.Jump());
            }
            else if (m_context.isDimensionSwitch)
            {
                m_context.isDimensionSwitch = false;
                m_context.SwitchState(m_factory.Switch());
            }
        }
    }
}
