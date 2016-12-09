/**
 * Buff类 
 **/
using UnityEngine;
using System.Collections;

public class Buff
{
    #region 玩家和敌人能够获取的Buff
    //玩家能够获得的Buff
    public enum PLAYERBUFF
    {
        ADDSPEED,
        ADDDEFEND,
        ADDACT,
        ADDBLOOD,
        ADDSKILLACT,
        CD,
        NONE
    }
    //敌人能够获得的Buff
    public enum MONSTERBUFF
    {
        FIREDAMAGE,
        ICEDAMAGE,
        POISIONDAMAGE,
        HARDDAMAGE,
        NONE
    }
    #endregion

    private PLAYERBUFF _PLAYERBUFF;
    private MONSTERBUFF _MONSTERBUFF;

    public Buff()
    {
        IsEnd = false;
        _PLAYERBUFF = PLAYERBUFF.NONE;
        _MONSTERBUFF = MONSTERBUFF.NONE;
        buffTime = 0;
        buffMission = 0;
        next = null;
    }
    /// <summary>
    /// 已抛弃
    /// </summary>
    /// <param name="buffTime"></param>
    /// <param name="buffMission"></param>
    /// <param name="buffData"></param>
    public Buff(float buffTime, float buffMission, float buffData)
    {
        this.buffTime = buffTime;
        this.buffMission = buffMission;
        this.buffData = buffData;
        this.IsEnd = false;
        this.next = null;
    }

    private float buffTime;
    private float buffMission;
    private float buffData;
    private bool isEnd;
    private bool isAdd;
    private bool isDoing;
    #region     特别说明：方法和属性是用来形成双向链表，目的是为了动态添加删除功能
    //用于双向链表
    private Buff next;//下一个Buff类
    private Buff previous;//前一个Buff类

    /// <summary>
    /// Buff类的链，暂时不用
    /// </summary>
    /// <param name="n">下一个Buff的对象</param>
    /// <returns>是否添加成功</returns>

    public bool addNextBuff(ref Buff n)
    {
        bool add = false;
        if (_PLAYERBUFF == n.PlayerBuff)
        {
            next = n;
            n.previous = this;
        }
        return add;
    }
    /// <summary>
    /// 将结束的Buff类重置，并将结束的Buff的前链置空
    /// </summary>
    public void setNextBuffEnd()
    {
        if (next != null)
        {
            next.IsEnd = true;
            next.previous = null;
        }
    }
    #endregion

    #region 不想多说这里的方法
    public float BuffTime
    {
        get
        {
            return buffTime;
        }

        set
        {
            buffTime = value;
        }
    }

    public float BuffMission
    {
        get
        {
            return buffMission;
        }

        set
        {
            buffMission = value;
        }
    }

    public PLAYERBUFF PlayerBuff
    {
        get
        {
            return _PLAYERBUFF;
        }

        set
        {
            _PLAYERBUFF = value;
        }
    }

    public MONSTERBUFF MonsterBuff
    {
        get
        {
            return _MONSTERBUFF;
        }

        set
        {
            _MONSTERBUFF = value;
        }
    }

    public float BuffData
    {
        get
        {
            return buffData;
        }

        set
        {
            buffData = value;
        }
    }

    public bool IsEnd
    {
        get
        {
            return isEnd;
        }

        set
        {
            isEnd = value;
        }
    }

    public bool IsAdd
    {
        get
        {
            return isAdd;
        }

        set
        {
            isAdd = value;
        }
    }

    public bool IsDoing
    {
        get
        {
            return isDoing;
        }

        set
        {
            isDoing = value;
        }
    }
    #endregion
}
