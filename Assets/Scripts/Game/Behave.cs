using UnityEngine;
using System.Collections;

public class Behave : TemplateClass<Behave>
{
    public enum ACTION
    {
        ATTACK,
        RUN,
        DEAD,
        ALIVE
    }
    protected ACTION _action;
    protected Animator ani;
    protected AnimatorStateInfo stateInfo;
    public Behave()
    {
        _action = ACTION.ALIVE;
        //ani.GetComponent<Animator>();
        //stateInfo = ani.GetCurrentAnimatorStateInfo(0);
    }
    virtual public void attackBehave(string aniName = "attack")
    {
        if (_action == ACTION.ALIVE)
            //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani.IsInTransition(0))
            //{
            ani.SetBool("Run", false);
        ani.SetTrigger(aniName);

        //}
    }
    virtual public void runBehave(string aniName = "run", bool isBool = true)
    {
        if (_action == ACTION.ALIVE)
            //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.BossStand01") && !ani.IsInTransition(0))
            //{
            //    ani.SetBool("attack", false);
            ani.SetBool(aniName, isBool);
        //}
    }
    virtual public void deadBehave(string aniName = "dead")
    {
        ani.SetTrigger("idle");
    }
    virtual public void aliveBehave(string aniName = "idle")
    {
        _action = ACTION.DEAD;
        //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack") && !ani.IsInTransition(0))
        //{
        //    ani.SetTrigger("attack");
        //}
        //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani.IsInTransition(0))
        //{
        //    ani.SetTrigger("run", false);
        //}
        ani.SetTrigger(aniName);
    }
}
