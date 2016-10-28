using UnityEngine;
using System.Collections;

public class Behave : MonoBehaviour
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
        ani.GetComponent<Animator>();
        stateInfo = ani.GetCurrentAnimatorStateInfo(0);
    }
    virtual protected void attackBehave()
    {
        if (_action == ACTION.ALIVE)
            if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani.IsInTransition(0))
            {
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
            }
    }
    virtual protected void runBehave()
    {
        if (_action == ACTION.ALIVE)
            if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack") && !ani.IsInTransition(0))
            {
                ani.SetBool("attack", false);
                ani.SetBool("run", true);
            }
    }
    virtual protected void deadBehave()
    {
        ani.SetBool("idle", true);
    }
    virtual protected void aliveBehave()
    {
        _action = ACTION.DEAD;
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack") && !ani.IsInTransition(0))
        {
            ani.SetBool("attack", false);
        }
        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani.IsInTransition(0))
        {
            ani.SetBool("run", false);
        }
        ani.SetBool("dead", true);
    }
}
