using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerJumpState : PlayerBaseState
    {
        public PlayerJumpState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            m_context.jumpCounts--;
            m_context.desireToJump = false;
            m_context.rb.velocity = new Vector2(m_context.rb.velocity.x, 0);
            m_context.jumpTimeCounter = 0;

            // calculate jump force base on jump height
            float jumpForce = Mathf.Sqrt(m_context.maxJumpHeight * -2 * (Physics2D.gravity.y));
            m_context.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        public override void UpdateState()
        {
            m_context.jumpTimeCounter += Time.deltaTime;

            // air control
            if (m_context.moveValue != Vector2.zero && m_context.moveValue.x < 0f)
                m_context.FacingLeft();
            else if (m_context.moveValue != Vector2.zero && m_context.moveValue.x > 0f)
                m_context.FacingRight();

            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            if ((m_context.isJumpRelease || m_context.jumpTimeCounter >= m_context.maxJumpTime) && m_context.rb.velocity.y > 0)
                m_context.rb.AddForce(Vector2.down * m_context.jumpCancelRate);

            m_context.MoveWithLimit(m_context.moveValue * m_context.playerAirMoveSpeedX, m_context.playerAirMaxSpeedX);
        }

        public override void ExitState()
        {
        
        }

        public override void CheckSwitchState()
        {

            if (m_context.rb.velocity.y < -0.001 && m_context.dimension == CameraManager.Dimension.TwoD)
            {
                m_context.SwitchState(m_factory.Fall());
            }
            else if (m_context.desireToJump && m_context.CanJump() && m_context.dimension == CameraManager.Dimension.TwoD)
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
