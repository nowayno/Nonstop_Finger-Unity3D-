using UnityEngine;
using System.Collections;

public class UISkill : MonoBehaviour
{
    UISprite icon;
    UISprite hover;
    UILabel cd;
    float cdtime;
    public float skilltime = 10;

    bool isready = true;
    bool skillready = true;
    // Use this for initialization
    void Start()
    {
        icon = transform.FindChild("icon").GetComponent<UISprite>();
        hover = transform.FindChild("hover").GetComponent<UISprite>();
        cd = transform.FindChild("cd").GetComponent<UILabel>();
        hover.fillAmount = 0;
        cd.text = "";
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        checkCD();
#endif

#if UNITY_IPHONE
        checkCD();
#endif

#if UNITY_STANDALONE_WIN
        checkCD();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (gameObject.name == "Skill01")
            {
                skill01Release();
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (gameObject.name == "Skill02")
            {
                skill02Release();
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (gameObject.name == "Skill03")
            {
                skill03Release();
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (gameObject.name == "Skill04")
            {
                skill04Release();
                onClick();
            }
        }
#endif

    }
    void checkCD()
    {
        if (isready == false)
        {
            if (cdtime > 0)
            {
                cdtime -= Time.deltaTime;
                hover.fillAmount = cdtime / skilltime;
                cd.text = string.Format("{0:F}", cdtime);
            }
            else
            {
                isready = true;
                skillready = true;
                hover.fillAmount = 0;
                cd.text = "";

            }
        }
    }
    public void onClick()
    {
        if (isready)
        {
            isready = false;
            cdtime = skilltime;
        }
    }
    public void skill01Release()
    {
        if (skillready)
        {
            skillready = false;
            GameObject.Find("Player").GetComponent<PlayerScript>().skillRelease(1);
        }
    }
    public void skill02Release()
    {
        if (skillready)
        {
            skillready = false;
            GameObject.Find("Player").GetComponent<PlayerScript>().skillRelease(2);
        }
    }
    public void skill03Release()
    {
        if (skillready)
        {
            skillready = false;
            GameObject.Find("Player").GetComponent<PlayerScript>().skillRelease(3);
        }
    }
    public void skill04Release()
    {
        if (skillready)
        {
            skillready = false;
            GameObject.Find("Player").GetComponent<PlayerScript>().skillRelease(4);
        }
    }
}