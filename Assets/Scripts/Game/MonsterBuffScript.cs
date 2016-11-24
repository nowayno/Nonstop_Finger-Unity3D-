using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterBuffScript : MonoBehaviour
{
    List<MonsterBuff> monsterBuffList;
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
                //buffDoing = true;
                monsterBuffList[index - 1].isAdd(true);
                //buffADD(monsterBuffList[index - 1].getBuff(), monsterBuffList[index - 1].getBuffData());
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
    public void buffClear()
    {
        monsterBuffList.Clear();
    }
}
