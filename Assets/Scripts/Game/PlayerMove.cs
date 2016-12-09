/**
 * 玩家移动
 * 
 **/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] moList;
    private bool flip = false;

    List<float> dirAll;
    int dirtyTag = 0;//这是一个很重要的标记，标记一旦出错，被攻击对象就会出现遗漏
    // Use this for initialization
    void Start()
    {
        dirAll = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        sortMoList();
        if (dirtyTag < moList.Length)
        {
            setDirtyTag();
            if (moList[dirtyTag].GetComponent<MonsterMove>().getDir() > 3.5f)
            {
                Run(moList[dirtyTag].transform);
            }
        }

    }
    //我们给敌人的远近排个序
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
    //获取最近敌人的名字，好告诉总管理器我要攻击谁
    public string nearMonsterName()
    {
        if (dirtyTag < moList.Length)
            return moList[dirtyTag].name;
        else
            return moList[moList.Length - 1].name;
    }
    //左边右边？我得转个向
    public void setFlip()
    {
        transform.Rotate(0,180,0);
    }
    //脏标记吧，敌人死了，我应该换个攻击对象或者奔跑对象
    public void setDirtyTag()
    {
        //玩家需要专心的攻击最近的敌人，直至打败他
        if ((moList[dirtyTag].GetComponent<MonsterScript>().isDead()) && (dirtyTag < moList.Length - 1))
            dirtyTag += 1;
    }
    //都死了，那就设置为0
    public void clearDirtyTag()
    {
        dirtyTag = 0;
    }
    
}