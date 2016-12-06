using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject go;
    // Use this for initialization
    void Start()
    {
        UIPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //UICamera.mainCamera.WorldToScreenPoint(Camera.main.ScreenToWorldPoint(go.transform.position));
        //Debug.Log(gameObject.GetComponent<UISprite>().fillAmount);
        //gameObject.transform.position = UICamera.mainCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(go.transform.position));
        UIPosition();
    }
    void UIPosition()
    {
        float goX = go.transform.position.x;
        float goY = go.transform.position.y + go.GetComponent<CapsuleCollider>().bounds.size.y;
        float goZ = go.transform.position.z;

        gameObject.transform.position = UICamera.mainCamera.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(new Vector3(goX, goY, 0)));
        //gameObject.transform.LookAt(UICamera.mainCamera.transform);
    }
    public void UIDamage(float damage, int which)
    {

    }
    void UIDamagePosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}
