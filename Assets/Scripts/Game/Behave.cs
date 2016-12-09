/**
 * 行为树的基类
 **/
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
    // Animator类，在从类中进行初始化
    protected ACTION _action;
    protected Animator ani;
    protected AnimatorStateInfo stateInfo;
    public Behave()
    {
        _action = ACTION.ALIVE;
        //ani.GetComponent<Animator>();
        //stateInfo = ani.GetCurrentAnimatorStateInfo(0);
    }

    #region 各种动作的处理，将动作都单独作为类使用，让其成为一个组件，并解耦
    /// <summary>
    /// 攻击动作
    /// </summary>
    /// <param name="aniName">Unity Animator中设置的动作名字，此处使用的是Trigger</param>
    virtual public void attackBehave(string aniName = "attack")
    {
        if (_action == ACTION.ALIVE)
            //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !ani.IsInTransition(0))
            //{
            ani.SetBool("Run", false);
        ani.SetTrigger(aniName);

        //}
    }
    /// <summary>
    /// 奔跑动作
    /// </summary>
    /// <param name="aniName">Unity Animator中设置的动作名字，此处使用的是Bool</param>
    /// <param name="isBool">是否奔跑，默认为奔跑true</param>
    virtual public void runBehave(string aniName = "run", bool isBool = true)
    {
        if (_action == ACTION.ALIVE)
            //if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.BossStand01") && !ani.IsInTransition(0))
            //{
            //    ani.SetBool("attack", false);
            ani.SetBool(aniName, isBool);
        //}
    }
    /// <summary>
    /// 死亡动作
    /// </summary>
    /// <param name="aniName">Unity Animator中设置的动作名字，暂时没有使用</param>
    virtual public void deadBehave(string aniName = "dead")
    {
        ani.SetTrigger("idle");
    }
    /// <summary>
    /// 存活的动作
    /// </summary>
    /// <param name="aniName">Unity Animator中设置的动作名字，暂时没有使用</param>
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
    #endregion
}
