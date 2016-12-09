/**
 * 动作类的玩家从类 
 **/
using UnityEngine;
public class PlayerBehave : Behave
{
    void Start()
    {
        ani = GetComponent<Animator>();
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);

    }
    void Update()
    {

    }
    public ACTION getAction()
    {
        return _action;
    }

    public void setAction(Behave.ACTION ac)
    {
        _action = ac;
    }

    public void changeSpeed(float speed)
    {
        if (speed < 1.0f)
            speed = 1.0f;
        ani.speed = speed;
    }

    override public void attackBehave(string aniName = "attack")
    {
        //ani.speed = 2.0f;
        //ani.SetBool("idle", false);
        base.attackBehave(aniName);
    }
    public override void runBehave(string aniName = "run", bool isBool = true)
    {
        //ani.SetBool("idle", false);
        base.runBehave(aniName,isBool);
    }
    public override void aliveBehave(string aniName = "dead")
    {
        base.aliveBehave(aniName);
    }
    public override void deadBehave(string aniName = "idle")
    {
        base.deadBehave(aniName);
    }
    //下面的还没有，忽略
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
