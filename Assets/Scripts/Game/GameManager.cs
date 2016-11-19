using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{
    int buffTarget = -1;
    public int mission = 0;
    int monsterAllDead = 0;

    public GameObject uiL;
    public GameObject playerGO;
    public GameObject[] monsterGOList;
    static List<float> monsterAttack;
    static List<float> playerAttack;
    List<MonsterBuff> monsterBuffList = new List<MonsterBuff>();
    List<PlayerBuff> playerBuffList = new List<PlayerBuff>();

    public List<MonsterBuff> MonsterBuffList
    {
        get
        {
            return monsterBuffList;
        }

        set
        {
            monsterBuffList = value;
        }
    }

    public List<PlayerBuff> PlayerBuffList
    {
        get
        {
            return playerBuffList;
        }

        set
        {
            playerBuffList = value;
        }
    }

    void Awake()
    {
        monsterAttack = new List<float>();
        playerAttack = new List<float>();
        //monsterGOList = new GameObject[5];
    }

    // Use this for initialization
    void Start()
    {

    }

    void initMonsterGameObject()
    {
        /*
         *List.add(go) 
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterAllDead >= 15)
        {
            monsterAllDead = 0;
            mission += 1;
            playerGO.GetComponent<PlayerScript>().missionBlood(mission);
            playerGO.GetComponent<PlayerBuffScript>().destoryAllBuff();
            //Debug.Log("the mission is " + mission);
        }
        if (playerGO.GetComponent<PlayerScript>().isDead() != true)
        {
            //Debug.Log(MonsterScript.deadnum);
            if (MonsterScript.deadnum >= 5)
            {
                playerGO.GetComponent<PlayerScript>().canNowAttack(false);
                MonsterScript.deadnum = 0;
                //deadNum();
                monsterAttack.Clear();
                playerAttack.Clear();
                playerGO.GetComponent<PlayerScript>().reLife();

                float dir = Random.Range(-0.4f, 0.4f) <= 0 ? -1 : 1;
                //Debug.Log(dir);
                int i = 0;
                foreach (GameObject m in monsterGOList)
                {
                    float pos = Random.Range(20, 30) * dir;
                    m.GetComponent<MonsterScript>().missionBlood(mission);
                    m.GetComponent<MonsterScript>().missionAct(mission);
                    m.GetComponent<MonsterScript>().Relife();
                    m.transform.position = playerGO.transform.localPosition + new Vector3(pos, 0, 0);
                    restoreUI(i);
                    restoreUI(5);
                    ++i;
                }

            }
            foreach (GameObject m in monsterGOList)
            {
                float dir = Vector3.Distance(m.transform.localPosition, playerGO.transform.localPosition);
                if (dir < 3.0f)
                {
                    playerGO.GetComponent<PlayerScript>().canNowAttack(true);
                    m.GetComponent<MonsterScript>().canNowAttack(true);
                }
                else
                {
                    //playerGO.GetComponent<PlayerScript>().canNowAttack(false);
                    m.GetComponent<MonsterScript>().canNowAttack(false);
                }
            }
        }
    }

    public void bloodUI(int index, float nowBlood, float blood, float damage)
    {
        UISprite uiObject = GameObject.Find("Blood0" + index).GetComponent<UISprite>();
        uiObject.fillAmount = (nowBlood - damage) / blood;
    }
    public void restoreUI(int index)
    {
        UISprite uiObject = GameObject.Find("Blood0" + index).GetComponent<UISprite>();
        uiObject.fillAmount = 1;
    }

    public void deadNum()
    {
        monsterAllDead += 1;
    }

    public void addMonsterBuff(MonsterBuff bfs, float tar_length)
    {
        foreach (GameObject go in monsterGOList)
        {
            float length = Vector3.Distance(playerGO.transform.localPosition, go.transform.localPosition);
            if (length <= tar_length)
            {
                go.GetComponent<MonsterBuffScript>().addBuff(bfs);
            }
        }
    }
    public void addPlayerBuff(PlayerBuff pfs)
    {
        playerGO.GetComponent<PlayerBuffScript>().addBuff(pfs);
    }

    public void monsterAttackplayer(float attack)
    {
        //monsterAttack.Insert(0, attack);
        //foreach (GameObject m in monsterGOList)
        //{
        //    float dir = Vector3.Distance(m.transform.localPosition, playerGO.transform.localPosition);
        //    if (dir < 3.0f)
        //    {
        //UILabel uiL = GameObject.Find("damage").GetComponent<UILabel>();

        GameObject uiLabel = Instantiate(uiL);
        uiLabel.transform.parent = GameObject.Find("UI Root").transform;
        uiLabel.GetComponent<UILabel>().text = attack.ToString();
        float goX = playerGO.transform.position.x;
        float goY = playerGO.transform.position.y;
        float goZ = playerGO.transform.position.z;
        uiLabel.transform.position = UICamera.mainCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(new Vector3(goX, goY, goZ)));
        uiLabel.transform.localScale = new Vector3(1, 1, 1);


        playerGO.GetComponent<PlayerScript>().beAttacked(attack);
        bloodUI(5, playerGO.GetComponent<PlayerScript>().getNowBlood(), playerGO.GetComponent<PlayerScript>().getBlood(), attack);
        //m.GetComponent<MonsterScript>().Attack(playerGO);
        //    }
        //}
    }

    public void playerAttackmonster(float attack)
    {
        //playerAttack.Insert(0, attack);
        if (playerGO.GetComponent<PlayerScript>().isDead() == false)
        {
            //UILabel uiL;
            int i = 0;
            foreach (GameObject m in monsterGOList)
            {
                //uiL = GameObject.Find("damage").GetComponent<UILabel>();
                if (m.GetComponent<MonsterScript>().isDead() == false)
                {
                    //uiL = GameObject.Find("damage").GetComponent<UILabel>();
                    GameObject uiLabel = Instantiate(uiL);
                    uiLabel.transform.parent = GameObject.Find("UI Root").transform;
                    uiLabel.GetComponent<UILabel>().text = attack.ToString();
    
                    float goX = m.transform.position.x;
                    float goY = m.transform.position.y;
                    float goZ = m.transform.position.z;
                    uiLabel.transform.position = UICamera.mainCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(new Vector3(goX, goY, goZ)));
                    uiLabel.transform.localScale = new Vector3(1, 1, 1);

                    m.GetComponent<MonsterScript>().beAttacked(attack);
                    bloodUI(i, m.GetComponent<MonsterScript>().getNowBlood(), m.GetComponent<MonsterScript>().getBlood(), attack);
                    break;
                }
                else
                {
                    //m.transform.position = new Vector3(100, 100, 0);
                }
                ++i;
            }
        }
    }
}
