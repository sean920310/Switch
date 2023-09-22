using PlayerState;

namespace PlayerStateMachine
{
    public class PlayerStateFactory
    {
        PlayerStatesManager _context;

        public PlayerStateFactory(PlayerStatesManager context)
        {
            _context = context;
        }

        public PlayerBaseState Idle()
        {
            return new PlayerIdleState(_context, this);
        }

        public PlayerBaseState Walk()
        {
            return new PlayerWalkState(_context, this);
        }
    }
}

