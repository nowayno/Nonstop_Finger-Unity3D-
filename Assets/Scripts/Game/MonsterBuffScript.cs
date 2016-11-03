using UnityEngine;
using System.Collections;

public class MonsterBuffScript : MonoBehaviour
{
    Buff buff;

    void Awake()
    {
        initBuff();
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
                buff.MonsterBuff = Buff.MONSTERBUFF.FIREDAMAGE;
                break;
            case 1:
                buff.MonsterBuff = Buff.MONSTERBUFF.ICEDAMAGE;
                break;
            case 2:
                buff.MonsterBuff = Buff.MONSTERBUFF.POISIONDAMAGE;
                break;
            case 3:
                buff.MonsterBuff = Buff.MONSTERBUFF.HARDDAMAGE;
                break;
            default:
                buff.MonsterBuff = Buff.MONSTERBUFF.NONE;
                break;
        }
    }

    // Use this for initialization
    void Start()
    {
        buff.BuffTime -= Time.deltaTime;
        if (buff.BuffTime <= 0)
        {
            buff.MonsterBuff = Buff.MONSTERBUFF.NONE;
            buff.IsEnd = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

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
