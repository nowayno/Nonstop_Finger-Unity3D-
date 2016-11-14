using UnityEngine;
using System.Collections;

public class GameCharator : MonoBehaviour
{

    public enum SKILL
    {
        SKILL1,
        SKILL2,
        SKILL3,
        SKILL4,
        SKILL5,
        SKILL6,
        SKILL7,
        SKILL8,
    }
    SKILL _skillWitch;
    public SKILL SkillWitch
    {
        get
        {
            return _skillWitch;
        }

        set
        {
            _skillWitch = value;
        }
    }

    private bool _isAction;
    private bool _isSkill;

    private int g_id;
    private float g_blood;
    private float g_attack;
    private float g_defend;
    private float g_speed;
    private int g_level;

    public int Id
    {
        get
        {
            return g_id;
        }

        set
        {
            g_id = value;
        }
    }

    public float Blood
    {
        get
        {
            return g_blood;
        }

        set
        {
            g_blood = value;
        }
    }

    public float Attack
    {
        get
        {
            return g_attack;
        }

        set
        {
            g_attack = value;
        }
    }

    public float Defend
    {
        get
        {
            return g_defend;
        }

        set
        {
            g_defend = value;
        }
    }

    public float Speed
    {
        get
        {
            return g_speed;
        }

        set
        {
            g_speed = value;
        }
    }

    public int Level
    {
        get
        {
            return g_level;
        }

        set
        {
            g_level = value;
        }
    }


}
