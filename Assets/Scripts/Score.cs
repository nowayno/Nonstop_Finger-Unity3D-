using UnityEngine;
using System.Collections;

public class Score
{
    private int max_mission;
    private int max_kill;

    public int Max_mission
    {
        get
        {
            return max_mission;
        }

        set
        {
            max_mission = value;
        }
    }

    public int Max_kill
    {
        get
        {
            return max_kill;
        }

        set
        {
            max_kill = value;
        }
    }
}
