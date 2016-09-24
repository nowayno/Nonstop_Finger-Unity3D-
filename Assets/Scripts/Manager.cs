using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static int mission;
    public static int score;

    public static Manager instance;
    // Use this for initialization
    void Start()
    {
        instance = new Manager();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addMission(int m)
    {
        mission = m + mission;
    }
    public void addScore(int s)
    {
        score = s + score;
    }
}
