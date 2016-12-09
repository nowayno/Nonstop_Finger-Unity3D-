using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] moList;
    private bool flip = false;

    List<float> dirAll;
    int dirtyTag = 0;
    // Use this for initialization
    void Start()
    {
        dirAll = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        sortMoList();
        //Debug.Log(dirtyTag + "  " + moList.Length);
        if (dirtyTag < moList.Length)
        {
            setDirtyTag();
            if (moList[dirtyTag].GetComponent<MonsterMove>().getDir() > 3.5f)
            {
                Run(moList[dirtyTag].transform);
            }
        }

    }
    public void sortMoList()
    {
        GameObject targetDir;
        for (int index = dirtyTag; index < 4; ++index)
        {
            if (moList[index].GetComponent<MonsterMove>().getDir() > moList[index + 1].GetComponent<MonsterMove>().getDir())
            {
                targetDir = moList[index + 1];
                moList[index + 1] = moList[index];
                moList[index] = targetDir;
            }
        }
    }
    public void Run(Transform trans)
    {
        GetComponent<PlayerBehave>().runBehave("Run");
        transform.position = Vector3.MoveTowards(transform.position, trans.position, Time.deltaTime);
    }
    public string nearMonsterName()
    {
        if (dirtyTag < moList.Length)
            return moList[dirtyTag].name;
        else
            return moList[moList.Length - 1].name;
    }
    public void setFlip()
    {
        transform.Rotate(0,180,0);
    }
    public void setDirtyTag()
    {
        if ((moList[dirtyTag].GetComponent<MonsterScript>().isDead()) && (dirtyTag < moList.Length - 1))
            dirtyTag += 1;
    }
    public void clearDirtyTag()
    {
        dirtyTag = 0;
    }
    
}