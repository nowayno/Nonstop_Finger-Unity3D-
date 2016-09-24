using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{
    public static float mission = 1;
    public static int score = 0;

    public static Manager instance;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        mission += Time.deltaTime;
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
