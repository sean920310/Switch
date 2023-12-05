public class BossBanditStateFactory
{
    BossBanditStateManager _context;

    public BossBanditStateFactory(BossBanditStateManager context)
    {
        _context = context;
    }

    public BossBanditBaseState Patrol()
    {
        return new BossBanditPatrolState(_context, this);
    }

    public BossBanditBaseState Chase()
    {
        return new BossBanditChaseState(_context, this);
    }

    public BossBanditBaseState Attack()
    {
        return new BossBanditAttackState(_context, this);
    }

    public BossBanditBaseState Hurt()
    {
        return new BossBanditHurtState(_context, this);
    }
}
