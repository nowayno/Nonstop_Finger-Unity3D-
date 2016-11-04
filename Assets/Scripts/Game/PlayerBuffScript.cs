using UnityEngine;
using System.Collections;

public class PlayerBuffScript : TemplateClass<PlayerBuffScript>
{
    Buff buff;
    GameManager gm;

    public Buff Buff
    {
        get
        {
            return buff;
        }
    }

    void Awake()
    {
        initBuff();
        gm = Camera.main.GetComponent<GameManager>();
        gm.PlayerBuffList.Add(this);
    }

    void initBuff()
    {
        buff = new Buff();
        buff.BuffTime = Random.Range(1.0f, 5.0f);
        buff.BuffMission = Random.Range(1.0f, 5.0f);
        buff.BuffData = Random.Range(0.1f, 1.0f);
        int r = Random.Range(0, 6);
        switch (r)
        {
            case 0:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDSPEED;
                break;
            case 1:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDDEFEND;
                break;
            case 2:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDACT;
                break;
            case 3:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDBLOOD;
                break;
            case 4:
                buff.PlayerBuff = Buff.PLAYERBUFF.ADDSKILLACT;
                break;
            case 5:
                buff.PlayerBuff = Buff.PLAYERBUFF.CD;
                break;
            default:
                buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
                break;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        buff.BuffTime -= Time.deltaTime;
        if (buff.BuffTime <= 0)
        {
            buff.PlayerBuff = Buff.PLAYERBUFF.NONE;
            buff.IsEnd = true;
        }
    }

    public void destroySelf()
    {
        if (buff.IsEnd)
        {
            buff = null;
            Destroy(this);
        }
    }
}
