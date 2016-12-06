using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public GameObject[] moList;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject go in moList)
        {
            float dir = Vector3.Distance(transform.position, go.transform.position);
            //transform.LookAt(go.transform);
            if (dir > 3.0f)
            {
                GetComponent<PlayerBehave>().runBehave("Run");
                transform.position = Vector3.MoveTowards(transform.position, go.transform.position, Time.deltaTime);
            }
        }
    }
}
