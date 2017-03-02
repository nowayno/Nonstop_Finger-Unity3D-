using UnityEngine;
using FairyGUI;
using System.Collections;

public class UIInfo : MonoBehaviour
{

    GComponent mainPanel;
    GList infoList;
    // Use this for initialization
    void Start()
    {
        FairyGUI.UIPanel fp = GameObject.Find("UIPanel").GetComponent<FairyGUI.UIPanel>();
        mainPanel = fp.ui;
        infoList = mainPanel.GetChild("n2") as GList;


        for (int i = 0; i < 9; ++i)
        {
            GComponent item = UIPackage.CreateObject("fairy", "info") as GComponent;
            GTextField text = item.GetChild("info_text") as GTextField;
            GTextField text2 = item.GetChild("info_detail") as GTextField;

            text.text = "信息";
            text2.text = "20";
            infoList.AddChild(item);
            //infoList.AddChild(text2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
