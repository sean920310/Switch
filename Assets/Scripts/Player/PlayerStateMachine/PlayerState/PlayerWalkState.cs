using UnityEngine;
using PlayerStateMachine;

namespace PlayerState
{
    public class PlayerWalkState : PlayerBaseState
    {
        public PlayerWalkState(PlayerStatesManager context, PlayerStateFactory factory)
            : base(context, factory)
        {
            _context = context;
            _factory = factory;
        }

        public override void EnterState()
        {
            
        }

        public override void UpdateState()
        {
            if(_context.MoveValue.x != 0)
            {
                if (_context.MoveValue.x < 0f)
                {
                    _context.FacingLeft();
                }
                else
                {
                    _context.FacingRight();
                }
            }


            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            if (_context.rb.velocity.x * _context.MoveValue.x < 0)
                _context.rb.velocity = new Vector2(0, _context.rb.velocity.y);

            _context.rb.AddForce(_context.MoveValue * Vector2.left * 100.0f, ForceMode.Force);
            _context.rb.velocity = new Vector2(Mathf.Clamp(_context.rb.velocity.x, -100.0f, 100.0f), _context.rb.velocity.y);
        }

        public override void ExitState()
        {
        
        }

        public override void CheckSwitchState()
        {
            if (_context.MoveValue.x == 0f)
                _context.SwitchState(_factory.Idle());
        }
    }
}
