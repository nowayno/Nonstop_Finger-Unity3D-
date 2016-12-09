using UnityEngine;
using System.Collections;

public class AutoDestory : MonoBehaviour
{
    //粒子销毁时间
    public float m_timer = 1.0f;
    // Use this for initialization
    void Start()
    {
        //销毁粒子
        Destroy(gameObject, m_timer);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
