/**
 * 敌人Buff处理脚本 
 * 有了Buff了，但要处理一下
 **/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterBuffScript : MonoBehaviour
{
    List<MonsterBuff> monsterBuffList;//敌人获得Buff集合，记录了当前身上的所有Buff
    bool buffDoing;
    void Awake()
    {
        monsterBuffList = new List<MonsterBuff>();
    }
    // Use this for initialization
    void Start()
    {

    }
    float ti = 0;
    // Update is called once per frame
    void Update()
    {
        ti += Time.deltaTime;
        for (int index = monsterBuffList.Count; index > 0; --index)
        {
            if (monsterBuffList[index - 1].isAdd() != true)
            {
                monsterBuffList[index - 1].isAdd(true);
                buffADD(monsterBuffList[index - 1].getBuff(), monsterBuffList[index - 1].getBuffData());
                monsterBuffList[index - 1].startBuff();
                //gameObject.GetComponent<PlayerScript>().buffChange(pb.getBuff(), false, pb.getBuffData());
            }

            if (monsterBuffList[index - 1].isEnd())
            {
                monsterBuffList[index - 1].isDoing(false);
                monsterBuffList[index - 1].isEnd(false);
                float data = monsterBuffList[index - 1].getBuffData() * -1;
                buffMIN(monsterBuffList[index - 1].getBuff(), data);
                monsterBuffList[index - 1].destroySelf();
                monsterBuffList.Remove(monsterBuffList[index - 1]);
            }
            else if (ti > 1 && monsterBuffList[index - 1].isDoing())
            {
                ti = 0;
                gameObject.GetComponent<MonsterScript>().addDamage(monsterBuffList[index - 1].getBuffData());
            }
        }
    }

    public void addBuff(MonsterBuff pbs)
    {
        monsterBuffList.Insert(0, pbs);
    }

    void buffADD(Buff buff, float data)
    {
        switch (buff.MonsterBuff)
        {
            case Buff.MONSTERBUFF.FIREDAMAGE:
                gameObject.GetComponent<MonsterScript>().addFireBuff(data);
                break;
            case Buff.MONSTERBUFF.ICEDAMAGE:
                gameObject.GetComponent<MonsterScript>().addIceBuff(data);
                break;
            case Buff.MONSTERBUFF.POISIONDAMAGE:
                gameObject.GetComponent<MonsterScript>().addPoisionBuff(data);
                break;
            case Buff.MONSTERBUFF.HARDDAMAGE:
                gameObject.GetComponent<MonsterScript>().addHardBuff();
                break;
        }
    }
    void buffMIN(Buff buff, float data)
    {
        switch (buff.MonsterBuff)
        {
            case Buff.MONSTERBUFF.FIREDAMAGE:
                gameObject.GetComponent<MonsterScript>().minFireBuff();
                break;
            case Buff.MONSTERBUFF.ICEDAMAGE:
                gameObject.GetComponent<MonsterScript>().minIceBuff();
                break;
            case Buff.MONSTERBUFF.POISIONDAMAGE:
                gameObject.GetComponent<MonsterScript>().minPoisionBuff();
                break;
            case Buff.MONSTERBUFF.HARDDAMAGE:
                gameObject.GetComponent<MonsterScript>().minHardBuff();
                break;
        }
    }
    //当敌人死了，重新生成的时候，其实是游戏体的复用，这样就不能让他死而复生的时候还有之前的Buff
    //还没打他呢，怎么就死了？这可不对
    public void buffClear()
    {
        foreach (MonsterBuff mb in monsterBuffList)
        {
            mb.isEnd(true);
        }
        monsterBuffList.Clear();
    }
}
