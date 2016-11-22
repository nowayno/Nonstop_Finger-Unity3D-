using UnityEngine;
using System.Collections;

public class UISkill : MonoBehaviour
{
    UISprite icon;
    UISprite hover;
    UILabel cd;
    float cdtime;
    float skilltime = 10;

    bool isready = true;
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
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (gameObject.name == "Skill02")
            {
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (gameObject.name == "Skill03")
            {
                onClick();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (gameObject.name == "Skill04")
            {
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
}