using UnityEngine;
public class MonsterBehave : Behave
{
    void Start()
    {
        ani = GetComponent<Animator>();
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
    }

    public MonsterBehave()
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

    public override void attackBehave(string aniName = "attack")
    {
        //ani.speed = 0.1f;
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
}
