using UnityEngine;
using System.Collections;

public class Buff
{
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

    public enum MONSTERBUFF
    {
        FIREDAMAGE,
        ICEDAMAGE,
        POISIONDAMAGE,
        HARDDAMAGE,
        NONE
    }
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
    private Buff next;
    private Buff previous;

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

    public void setNextBuffEnd()
    {
        if (next != null)
        {
            next.IsEnd = true;
            next.previous = null;
        }
    }

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
}
