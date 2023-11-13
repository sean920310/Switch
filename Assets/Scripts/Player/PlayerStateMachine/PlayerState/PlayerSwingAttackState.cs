using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerSwingAttackState : PlayerBaseState
    {
        float m_attackCounter = 0;
        const float SWING_LENGTH = 0.583f;

        public PlayerSwingAttackState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            m_context.isAttackPress = false;
            m_context.MoveWithLimit(Vector2.zero, 0);

            m_context.Animator.SetTrigger("isAttack");
            m_attackCounter = 0;
        }

        public override void UpdateState()
        {
            if (m_context.CheckOnFloor())
            {
                m_context.rb.velocity = new Vector2(0f, 0f);
            }

            if (m_context.moveValue != Vector2.zero && m_context.moveValue.x < 0f)
                m_context.FacingLeft();
            else if (m_context.moveValue != Vector2.zero && m_context.moveValue.x > 0f)
                m_context.FacingRight();

            m_attackCounter += Time.deltaTime;

            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {
            m_context.Animator.ResetTrigger("isAttack");

        }

        public override void CheckSwitchState()
        {
            if (m_attackCounter > SWING_LENGTH)
            {
                m_context.SwitchState(m_factory.Idle());
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
