using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerHurtState : PlayerBaseState
    {
        private Color hurtColor;
        public PlayerHurtState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            m_context = context;
            m_factory = factory;
        }

        public override void EnterState()
        {
            m_context.MoveWithLimit(Vector2.zero, 0);
            hurtColor = m_context.HurtColor;
            hurtColor.a = 1f;
            m_context.Material.SetColor("_TintColor", hurtColor);
            m_context.Animator.SetTrigger("isDamage");
        }

        public override void UpdateState()
        {
            if (m_context.CheckOnFloor())
            {
                m_context.rb.velocity = new Vector2(0f, 0f);
            }
            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            if (hurtColor.a > 0)
            {
                hurtColor.a = Mathf.Clamp01(hurtColor.a - 5 * Time.deltaTime);
                m_context.Material.SetColor("_TintColor", hurtColor);
            }
        }

        public override void ExitState()
        {
            m_context.Animator.ResetTrigger("isDamage");
            hurtColor.a = 0;
            m_context.Material.SetColor("_TintColor", hurtColor);

        }

        public override void CheckSwitchState()
        {
            if (hurtColor.a <= 0)
            {
                m_context.SwitchState(m_factory.Idle());
            }
        }
    }
}
