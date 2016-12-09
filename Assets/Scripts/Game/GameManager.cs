/**
 * 游戏角色的总管理器
 * 非常重要的类，但不知道后面会不会弱化这个类的作用
 * 这里的调用比较频繁
 **/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : TemplateClass<GameManager>
{
    int buffTarget = -1;
    public int mission = 1;
    int monsterAllDead = 0;
    float tempDir = 1;

    public GameObject uiL; //扣血显示UILabel
    public GameObject playerGO; //玩家游戏体
    public GameObject[] monsterGOList; //敌人游戏体，五个角色的复用
    static List<float> monsterAttack; //敌人的攻击数组，好像不用了,参考MonsterScript
    static List<float> playerAttack; //玩家的攻击数组，好像不用了，参考PlayerScript
    List<MonsterBuff> monsterBuffList = new List<MonsterBuff>(); //参考MonsterBuffScript
    List<PlayerBuff> playerBuffList = new List<PlayerBuff>(); //参考PlayerBuffScript

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
        //SkillCreat sc = new SkillCreat();
        //sc.skill01Create();
        //sc.skill02Create();
        //sc.skill03Create();
        //sc.skill04Create();
        //sc.skill05Create();
        //sc.skill06Create();
        //sc.skill07Create();
        //sc.skill08Create();
        //除了玩家和敌人的角色信息获取之外的信息获取
        OtherCreate oc = new OtherCreate();
        oc.usingSkill(1, 2, 3, 4);//这里获取了玩家所使用的技能信息

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
    }

    // Update is called once per frame
    void Update()
    {
        //当死亡总数达到了15，则进入下一关
        if (monsterAllDead >= 15)
        {
            monsterAllDead = 0;
            mission += 1;

            playerGO.GetComponent<PlayerScript>().missionBlood(mission); //玩家的血量根据关卡改变
            playerGO.GetComponent<PlayerBuffScript>().destoryAllBuff(); //清除玩家的Buff，只有进入下一关清除
            //Debug.Log("the mission is " + mission);
        }
        //玩家不死，战斗不止
        if (playerGO.GetComponent<PlayerScript>().isDead() != true)
        {

            //敌人死亡数量达到了5，也就是所有敌人死亡
            if (MonsterScript.deadnum >= 5)
            {
                playerGO.GetComponent<PlayerMove>().clearDirtyTag();//详情请见PlayerMove，主要是对敌人的标记
                playerGO.GetComponent<PlayerScript>().canNowAttack(false);//详情请见PlayerScript，旨在玩家不能攻击死亡角色和超出范围角色

                MonsterScript.deadnum = 0;
                //各种清除，详情见相关XxxxScript
                monsterAttack.Clear();
                playerAttack.Clear();
                //怎么，难道敌人死了，你的血量不还原吗
                playerGO.GetComponent<PlayerScript>().reLife();

                //以下的相关操作，是用来生成死亡敌人的重新生成
                float dir = Random.Range(-0.4f, 0.4f) <= 0 ? -1 : 1;

                if (dir != tempDir)
                    playerGO.GetComponent<PlayerMove>().setFlip();//详情见PlayerMove，用来反转角色
                tempDir = dir;

                //所以咯，别指望重新生成的敌人血量是0
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
            //这个攻击判断暂且放这里吧，可能会移走到各自的相关脚本中，也可能不会
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

    #region 一下方法太血腥，因为要战斗就要站到方法，而战斗避免不了扣血
    public void deadNum()
    {
        monsterAllDead += 1;
    }
    /// <summary>
    /// 给敌人一点点Buff吧
    /// </summary>
    /// <param name="bfs">给什么Buff呢</param>
    /// <param name="tar_length">有多远呢</param>
    public void addMonsterBuff(MonsterBuff bfs, float tar_length)
    {
        foreach (GameObject go in monsterGOList)
        {
            float length = Vector3.Distance(playerGO.transform.localPosition, go.transform.localPosition);
            if (length <= tar_length)
            {
                go.GetComponent<MonsterBuffScript>().addBuff(bfs);//你会在那个尖括号里面的文件中找到信息
            }
        }
    }
    /// <summary>
    /// 给玩家一点Buff吧
    /// </summary>
    /// <param name="pfs">给什么Buff呢</param>
    public void addPlayerBuff(PlayerBuff pfs)
    {
        playerGO.GetComponent<PlayerBuffScript>().addBuff(pfs);//你会在那个尖括号里面的文件中找到信息
    }
    /// <summary>
    /// 敌人攻击你啦
    /// </summary>
    /// <param name="attack">给你一击</param>
    public void monsterAttackplayer(float attack)
    {
        bloodUI(5, playerGO, attack);
        playerGO.GetComponent<PlayerScript>().beAttacked(attack);

        //bloodUI(5, playerGO.GetComponent<PlayerScript>().getNowBlood(), playerGO.GetComponent<PlayerScript>().getBlood(), attack);
        //m.GetComponent<MonsterScript>().Attack(playerGO);
    }
    /// <summary>
    /// 你得还击
    /// </summary>
    /// <param name="attack">给敌人一击</param>
    public void playerAttackmonster(float attack)
    {
        //playerAttack.Insert(0, attack);
        if (playerGO.GetComponent<PlayerScript>().isDead() == false)
        {
            //或许我该给这个变量一个好名字，我就不用解释了
            //我得知道我打了第几个敌人，要对他的血条做什么
            int i = 0;
            string name = playerGO.GetComponent<PlayerMove>().nearMonsterName();
            //可能疑问啦，记住这里和PlayerMove里面是不一样的，那里重排序，这里没有，搞不好以后我会合成一个，但现在要分清
            //我要打的是离我最近的那个敌人
            foreach (GameObject m in monsterGOList)
            {
                //这里就能找到了
                if ((m.GetComponent<MonsterScript>().isDead() == false) && (name == m.name))
                {
                    bloodUI(i, m, attack);
                    m.GetComponent<MonsterScript>().beAttacked(attack);

                    break;
                }
                ++i;
            }
        }
    }
    /// <summary>
    /// 这个方法是用来生成攻击生成的攻击力展示方法
    /// </summary>
    /// <param name="i">你要打第几个敌人啊</param>
    /// <param name="m">你要打的敌人</param>
    /// <param name="attack">给他一击</param>
    public void bloodUI(int i, GameObject m, float attack)
    {
        GameObject uiLabel = Instantiate(uiL);
        uiLabel.transform.parent = GameObject.Find("UI Root").transform;//记着在执行挂父挂子操作，一定要实例化，实例化，实例化，见上方
        uiLabel.GetComponent<UILabel>().text = string.Format("{0:F}", attack);//保留小数点后两位

        //我打第一个，不可能让攻击力显示跑到第二个敌人身上，不科学
        float goX = m.transform.position.x;
        float goY = m.transform.position.y + m.GetComponent<CapsuleCollider>().bounds.size.y + 2.0f;
        float goZ = m.transform.position.z;
        uiLabel.transform.position = UICamera.mainCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(new Vector3(goX, goY, 0)));
        uiLabel.transform.localScale = new Vector3(1, 1, 1);

        m.GetComponent<MonsterScript>().beAttacked(attack);
        //有趣，可这个方法是用来更新血条的！！！
        bloodUI(i, m.GetComponent<MonsterScript>().getNowBlood(), m.GetComponent<MonsterScript>().getBlood(), attack);
    }
    /// <summary>
    /// 血条更新方法
    /// </summary>
    /// <param name="index">更新第几个血条呢</param>
    /// <param name="nowBlood">他现在有多少血量了</param>
    /// <param name="blood">他初始血量是多少呢</param>
    /// <param name="damage">不管那么多，来一击再说</param>
    public void bloodUI(int index, float nowBlood, float blood, float damage)
    {
        UISprite uiObject = GameObject.Find("Blood0" + index).GetComponent<UISprite>();
        uiObject.fillAmount = (nowBlood - damage) / blood;
        //Debug.Log(damage);
    }
    /// <summary>
    /// 我不想在敌人死后我的血量不恢复，也不期待敌人的血量一直保持死亡状态，太没挑战了
    /// </summary>
    /// <param name="index">恢复谁的血条呢</param>
    public void restoreUI(int index)
    {
        UISprite uiObject = GameObject.Find("Blood0" + index).GetComponent<UISprite>();
        uiObject.fillAmount = 1;
    }
    /// <summary>
    /// 差点忘了，我还有技能
    /// </summary>
    /// <param name="skill">呼唤技能吧</param>
    /// 技能是范围内群攻，打一个人怎么行
    public void playerSkillAttackMonster(Skill skill)
    {
        if (playerGO.GetComponent<PlayerScript>().isDead() == false)
        {
            int i = 0;
            foreach (GameObject m in monsterGOList)
            {
                if ((m.GetComponent<MonsterScript>().isDead() == false) && (m.GetComponent<MonsterMove>().getDir() <= skill.Skill_Dir))
                {
                    bloodUI(i, m, skill.Skill_attack);
                    m.GetComponent<MonsterScript>().beAttacked(skill.Skill_tattack);
                }
                ++i;
            }
        }
    }
    #endregion
}
