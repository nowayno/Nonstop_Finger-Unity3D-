public class PlayerBehave : Behave
{
    public PlayerBehave()
    {

    }
    override protected void attackBehave()
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
    protected void skill01Behave()
    {
        ani.SetBool("skill01", true);
    }
    protected void skill02Behave()
    {
        ani.SetBool("skill02", true);
    }
    protected void skill03Behave()
    {
        ani.SetBool("skill03", true);
    }
    protected void skill04Behave()
    {
        ani.SetBool("skill04", true);
    }
    protected void skill05Behave()
    {
        ani.SetBool("skill05", true);
    }
    protected void skill06Behave()
    {
        ani.SetBool("skill06", true);
    }
    protected void skill07Behave()
    {
        ani.SetBool("skill07", true);
    }
    protected void skill08Behave()
    {
        ani.SetBool("skill08", true);
    }
}
