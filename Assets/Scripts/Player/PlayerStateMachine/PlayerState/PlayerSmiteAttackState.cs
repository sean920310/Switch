using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerSmiteAttackState : PlayerBaseState
    {
        float m_attackCounter = 0;
        const float SMITE_LENGTH = 0.75f;

        public PlayerSmiteAttackState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            m_context.isAttackPress = false;

            m_context.Animator.SetTrigger("isAttack");
            m_attackCounter = 0;

            m_context.SmiteSound.PlayDelayed(0.5f);
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

            //if (m_context.SmiteSound.isPlaying)
            //    m_context.SmiteSound.Stop();
        }

        public override void CheckSwitchState()
        {
            if (m_attackCounter > SMITE_LENGTH)
            {
                m_context.SwitchState(m_factory.Fall());
            }
            else if (m_context.CheckOnFloor())
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
