using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerWalk3DState : PlayerBaseState
    {
        public PlayerWalk3DState(PlayerStatesManager context, PlayerStateFactory factory)
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
            if (m_context.moveValue.x != 0)
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

            if (!m_context.FootStepSound.isPlaying)
                m_context.FootStepSound.Play();
            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {

            if (m_context.rb.velocity.x * m_context.moveValue.x <= 0)
                m_context.rb.velocity = new Vector2(0, m_context.rb.velocity.y);

            if (m_context.rb.velocity.y * m_context.moveValue.y <= 0)
                m_context.rb.velocity = new Vector2(m_context.rb.velocity.x, 0);

            m_context.MoveWithLimit3D(m_context.moveValue * m_context.playerMoveSpeedX, m_context.playerMaxSpeedX);
        }

        public override void ExitState()
        {
            m_context.Animator.SetBool("isMoving", false);
            if (m_context.FootStepSound.isPlaying)
                m_context.FootStepSound.Pause();
        }

        public override void CheckSwitchState()
        {
            if (m_context.moveValue.x == 0f && m_context.moveValue.y == 0f)
            {
                m_context.SwitchState(m_factory.Idle());
            }
            else if (m_context.isDimensionSwitch)
            {
                m_context.isDimensionSwitch = false;
                m_context.SwitchState(m_factory.Switch());
            }
        }
    }
}
