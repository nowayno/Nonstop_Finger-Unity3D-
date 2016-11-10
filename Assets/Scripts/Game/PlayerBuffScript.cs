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
            if (playerBuffList[index - 1].isEnd())
            {
                float data = playerBuffList[index - 1].getBuffData() * -1;
                buffMIN(playerBuffList[index - 1].getBuff(), data);
                playerBuffList.Remove(playerBuffList[index - 1]);
                playerBuffList[index - 1].destroySelf();
            }
            if (playerBuffList[index - 1].isAdd() != true)
            {
                playerBuffList[index - 1].isAdd(true);
                buffADD(playerBuffList[index - 1].getBuff(), playerBuffList[index - 1].getBuffData());
                playerBuffList[index - 1].startBuff();
                //gameObject.GetComponent<PlayerScript>().buffChange(pb.getBuff(), false, pb.getBuffData());
            }
        }
    }

    public void addBuff(PlayerBuff pbs)
    {
        playerBuffList.Insert(0, pbs);
    }

    void buffADD(Buff buff, float data)
    {
        switch (buff.PlayerBuff)
        {
            case Buff.PLAYERBUFF.ADDSPEED:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDDEFEND:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDACT:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDBLOOD:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDSKILLACT:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.CD:
                gameObject.GetComponent<PlayerScript>().addSpeedBuff(-data);
                break;
        }
    }
    void buffMIN(Buff buff, float data)
    {
        switch (buff.PlayerBuff)
        {
            case Buff.PLAYERBUFF.ADDSPEED:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDDEFEND:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDACT:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDBLOOD:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.ADDSKILLACT:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(data);
                break;
            case Buff.PLAYERBUFF.CD:
                gameObject.GetComponent<PlayerScript>().minSpeedBuff(-data);
                break;
        }
    }
}
