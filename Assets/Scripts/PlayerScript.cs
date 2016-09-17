/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 14:20:34
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    Player player;
    // Use this for initialization
    void Start()
    {
        player = new Player();
        DoAction da = new DoAction();

        player = da.readData<Player>(player);

        Debug.Log("blood:" + player.P_blood + "\nattack" + player.P_attack);
        BUFF _buff = new BUFF();
        _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDACT;
        Debug.Log("addAct:" + da.addBuff(0, _buff, player.P_attack, 0.5f));
        _buff._PLAYERBUFF = BUFF.PLAYERBUFF.ADDBLOOD;
        Debug.Log("addBlood:" + da.addBuff(0, _buff, player.P_blood, -0.3f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
