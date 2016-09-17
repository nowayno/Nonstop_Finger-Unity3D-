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
        IBehave pb = new PlayerBehave();
        float act = player.P_attack;
        pb.buffBehave(ref act, 2);
        Debug.Log("addAct:" + act);
        float blood = player.P_blood;
        pb.buffBehave(ref blood, 3);
        Debug.Log("addBlood:" + blood);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
