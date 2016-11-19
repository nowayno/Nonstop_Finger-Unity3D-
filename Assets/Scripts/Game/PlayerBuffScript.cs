using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBuffScript : MonoBehaviour
{
    List<PlayerBuff> playerBuffList;

    void Awake()
    {
        playerBuffList = new List<PlayerBuff>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int index = playerBuffList.Count; index > 0; --index)
        {

        }
        for (int index = playerBuffList.Count; index > 0; --index)
        {
            //Debug.Log("index:" + playerBuffList.Count + " data:" + playerBuffList[index - 1].getBuffData() +" t:" + playerBuffList[index - 1].getBuff().BuffTime + " time:" + Time.time);
            if (playerBuffList[index - 1].isAdd() != true)
            {
                //Debug.Log("Buff is added");
                playerBuffList[index - 1].isAdd(true);
                buffADD(playerBuffList[index - 1].getBuff(), playerBuffList[index - 1].getBuffData());
                playerBuffList[index - 1].startBuff();
                //gameObject.GetComponent<PlayerScript>().buffChange(pb.getBuff(), false, pb.getBuffData());
            }
            if (playerBuffList[index - 1].isEnd())
            {
                //Debug.Log("Buff is ending");
                playerBuffList[index - 1].isEnd(false);
                float data = playerBuffList[index - 1].getBuffData() * -1;
                buffMIN(playerBuffList[index - 1].getBuff(), data);
                playerBuffList[index - 1].destroySelf();
                playerBuffList.Remove(playerBuffList[index - 1]);
            }
        }
    }

    public void addBuff(PlayerBuff pbs)
    {
        //Debug.Log("Adding buff" + " count:" + playerBuffList.Count);
        playerBuffList.Insert(0, pbs);
    }
    public void destoryAllBuff()
    {
        for (int index = playerBuffList.Count; index > 0; --index)
        {
            //playerBuffList[index - 1].isEnd(true);
            //float data = playerBuffList[index - 1].getBuffData() * -1;
            //buffMIN(playerBuffList[index - 1].getBuff(), data);
            //playerBuffList[index - 1].destroySelf();
            playerBuffList.Remove(playerBuffList[index - 1]);
        }
    }
    void buffADD(Buff buff, float data)
    {
        switch (buff.PlayerBuff)
        {
            case Buff.PLAYERBUFF.ADDSPEED:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(-data);
                break;
            case Buff.PLAYERBUFF.ADDDEFEND:
                gameObject.GetComponent<PlayerScript>().addDefendBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDACT:
                gameObject.GetComponent<PlayerScript>().addActBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDBLOOD:
                gameObject.GetComponent<PlayerScript>().addBloodBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDSKILLACT:
                gameObject.GetComponent<PlayerScript>().addSkillActBuff(data);
                break;
            case Buff.PLAYERBUFF.CD:
                gameObject.GetComponent<PlayerScript>().addCDBuff(-data);
                break;
        }
    }
    void buffMIN(Buff buff, float data)
    {
        switch (buff.PlayerBuff)
        {
            case Buff.PLAYERBUFF.ADDSPEED:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(-data);
                break;
            case Buff.PLAYERBUFF.ADDDEFEND:
                gameObject.GetComponent<PlayerScript>().minDefendBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDACT:
                gameObject.GetComponent<PlayerScript>().minActBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDBLOOD:
                gameObject.GetComponent<PlayerScript>().minBloodBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDSKILLACT:
                gameObject.GetComponent<PlayerScript>().minSkillActBuff(data);
                break;
            case Buff.PLAYERBUFF.CD:
                gameObject.GetComponent<PlayerScript>().minCDBuff(-data);
                break;
        }
    }
}
