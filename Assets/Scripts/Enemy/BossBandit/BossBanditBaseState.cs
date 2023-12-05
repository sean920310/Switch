using UnityEngine;

// This is the base of the finite state machine
public abstract class BossBanditBaseState
{

    protected BossBanditStateManager _context;
    protected BossBanditStateFactory _factory;

    public BossBanditBaseState(BossBanditStateManager context, BossBanditStateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();

}