//using UnityEngine;
//using System.Collections;

//public class BuffAdd : MonoBehaviour
//{

//    float buffTime = 0;
//    float buffMission = 0;
//    float data = 0;
//    int tempwhich = 0;

//    bool tempMission = false;
//    bool isBuffTime = false;
//    bool isBuffMission = false;

//    GameObject m_go;

//    BUFF _b;

//    float debugTime = 0;
//    bool debugBool = true;

//    void Awake()
//    {
//        // go = gameObject;
//        _b = new BUFF();
//    }
//    // Use this for initialization
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //debugTime += Time.deltaTime;
//        //if(debugBool)
//        //{
//        //    go.AddComponent<BuffAdd>();
//        //    float a = Random.Range(1.0f, 5.0f);
//        //    go.GetComponent<BuffAdd>().addBUFF(_buff, a, -1);
//        //    debugBool = false;
//        //}
//        //if (debugTime >= 5 && debugTime <= 10)
//        //{
//        //    Debug.Log("time " + buffTime + " mission" + buffMission);
//        //    go.AddComponent<BuffAdd>();
//        //    float a = Random.Range(1.0f, 5.0f);
//        //    go.GetComponent<BuffAdd>().addBUFF(_buff, a, -1);
//        //}

//        if (isBuffTime == false && isBuffMission == false)
//        {
//            Debug.Log("time up or mission over" + this.GetInstanceID());
//            Destroy(this);
//        }
//        else if (isBuffTime && isBuffMission == false)
//        {
//            buffTime -= Time.deltaTime;
//            if (buffTime <= 0)
//            {
//                isBuffTime = false;
//                //debugBool = false;
//            }
//        }
//        else if (isBuffTime == false && isBuffMission == true)
//        {
//            if (tempMission == false)
//            {
//                tempMission = true;
//                buffMission += Manager.mission;
//            }
//            if (Manager.mission == buffMission)
//            {
//                isBuffMission = false;
//                //debugBool = false;
//            }
//        }
//        else if (isBuffTime && isBuffMission)
//        {
//            buffTime -= Time.deltaTime;
//            if (buffTime <= 0)
//            {
//                isBuffTime = false;
//            }
//            buffMission += Manager.mission;
//            if (Manager.mission == buffMission)
//            {
//                isBuffMission = false;
//            }
//        }
//    }

//    public void addBUFF(GameObject go, int which, BUFF _buff, params float[] param)
//    {

//        if (param.Length > 1)
//        {
//            _b = _buff;
//            m_go = go;
//            tempwhich = which;

//            if (param[1] == -1)
//            {
//                buffTime = param[0];
//                isBuffTime = true;
//            }
//            else if (param[1] == 0)
//            {
//                buffMission = param[0];
//                isBuffMission = true;
//            }
//            else
//            {
//                buffTime = param[0];
//                buffMission = param[1];
//                isBuffTime = true;
//                isBuffMission = true;
//            }
//            data = param[2];
//            if (which == 0)
//            {
//                go.GetComponent<PlayerScript>().buffChange(_b, false, param);
//            }
//            else if (which == 1)
//            {
//                go.GetComponent<MonsterScript>().buffChange(_b, false, param);
//            }
//        }

//    }
//    public void minBuff()
//    {
//        if (tempwhich == 0)
//        {
//            m_go.GetComponent<PlayerScript>().buffChange(_b, true, -data);
//        }
//        else if (tempwhich == 1)
//        {
//            m_go.GetComponent<MonsterScript>().buffChange(_b, true, -data);
//        }
//    }

//}
