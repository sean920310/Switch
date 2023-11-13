using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerWalkState : PlayerBaseState
    {
        public PlayerWalkState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            // onGround Animation
            m_context.Animator.SetBool("onGround", true);
            m_context.Animator.SetBool("isMoving", true);
        }

        public override void UpdateState()
        {
            if(m_context.moveValue.x != 0)
            {
                if (m_context.moveValue.x < 0f)
                {
                    m_context.FacingLeft();
                }
                else
                {
                    m_context.FacingRight();
                }
            }


            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            if (m_context.rb.velocity.x * m_context.moveValue.x <= 0)
            {
                m_context.rb.velocity = new Vector2(0, m_context.rb.velocity.y);
            }

            m_context.MoveWithLimit(m_context.moveValue * m_context.playerMoveSpeedX, m_context.playerMaxSpeedX);
        }

        public override void ExitState()
        {
            m_context.Animator.SetBool("isMoving", false);
        }

        public override void CheckSwitchState()
        {
            if (m_context.moveValue.x == 0f)
            {
                m_context.SwitchState(m_factory.Idle());
            }
            else if (m_context.desireToJump && m_context.CanJump())
            {
                m_context.SwitchState(m_factory.Jump());
            }
            else if (m_context.rb.velocity.y < -0.001)
            {
                m_context.SwitchState(m_factory.Fall());
            }
            else if (m_context.isDimensionSwitch)
            {
                m_context.isDimensionSwitch = false;
                m_context.SwitchState(m_factory.Switch());
            }
            else if (m_context.isAttackPress && m_context.canAttack)
            {
                m_context.SwitchState(m_factory.SwingAttack());
            }
        }
    }
}
