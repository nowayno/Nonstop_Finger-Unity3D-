/*
 * 作者：佯疯(crazYoung) 
 * 起始时间：2016/9/16 14:20:34
 * 完成时间：
 */
using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    static Player player;
    Skill skill;
    // Use this for initialization
    void Start()
    {
        player = new Player();
        player = DoAction.getInstance().readData<Player>(player);
        Debug.Log("Player:\n" + "player blood:" + player.P_blood + "\nplayer attack:" + player.P_attack + "\nplayer defend:" + player.P_defend + "\nplayer speed:" + player.P_speed);

        skill = new Skill();
        skill = DoAction.getInstance().readData<Skill>(skill);
        Debug.Log("Skill:\n" + "skill attack:" + skill.Skill_attack + "\nskill cd:" + skill.Skill_CD + "\nskill buff:" + skill.Buff._MONSTERBUFF);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void hur()
    {
        player.P_blood -= 5;
        Debug.Log("player hurt:" + player.P_blood);
    }
}
