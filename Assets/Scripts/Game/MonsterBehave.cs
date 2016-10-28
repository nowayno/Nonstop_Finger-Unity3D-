public class MonsterBehave : Behave
{
    public MonsterBehave()
    {
        
    }

    protected override void attackBehave()
    {
        ani.SetBool("idle", false);
        base.attackBehave();
    }
    protected override void runBehave()
    {
        ani.SetBool("idle", false);
        base.runBehave();
    }
    protected override void aliveBehave()
    {
        base.aliveBehave();
    }

    protected override void deadBehave()
    {
        base.deadBehave();
    }
}
