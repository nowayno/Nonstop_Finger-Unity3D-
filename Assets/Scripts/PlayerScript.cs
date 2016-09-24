/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 14:20:34
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    GameObject p_go;

    Player player;
    Skill skill;

    int p_id;
    float p_blood;
    float p_attack;
    Skill p_skill;
    float p_defend;
    float p_speed;
    int p_level;
    // Use this for initialization
    void Start()
    {
        p_go = gameObject;

        player = new Player();
        player = DoAction.getInstance().readData<Player>(player);
        p_id = player.P_id;
        p_blood = player.P_blood;
        p_attack = player.P_attack;
        p_skill = player.P_skill;
        p_defend = player.P_defend;
        p_speed = player.P_speed;
        p_level = player.P_level;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
