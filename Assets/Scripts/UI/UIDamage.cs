using UnityEngine;
using System.Collections;

public class UIDamage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    float y;
    // Update is called once per frame
    void Update()
    {
        y += Time.deltaTime * 0.1f;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, y, gameObject.transform.position.z);
    }
}
