using PlayerState;

namespace PlayerStateMachine
{
    public class PlayerStateFactory
    {
        PlayerStatesManager m_context;

        public PlayerStateFactory(PlayerStatesManager context)
        {
            m_context = context;
        }

        public PlayerBaseState Idle()
        {
            return new PlayerIdleState(m_context, this);
        }

        public PlayerBaseState Walk()
        {
            return new PlayerWalkState(m_context, this);
        }
        public PlayerBaseState Walk3D()
        {
            return new PlayerWalk3DState(m_context, this);
        }
        public PlayerBaseState Jump()
        {
            return new PlayerJumpState(m_context, this);
        }
        public PlayerBaseState Fall()
        {
            return new PlayerFallState(m_context, this);
        }
        public PlayerBaseState Switch()
        {
            return new PlayerSwitchState(m_context, this);
        }
        public PlayerBaseState SwingAttack()
        {
            return new PlayerSwingAttackState(m_context, this);
        }
        public PlayerBaseState SmiteAttack()
        {
            return new PlayerSmiteAttackState(m_context, this);
        }
        public PlayerHurtState Hurt()
        {
            return new PlayerHurtState(m_context, this);
        }
    }
}

