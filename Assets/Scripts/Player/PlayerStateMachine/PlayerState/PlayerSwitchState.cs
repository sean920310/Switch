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
                Debug.Log("EnterState: TwoD");
                m_context.rb.gravityScale = 1f;
            }
            else
            {
                Debug.Log("EnterState: ThreeD");
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
