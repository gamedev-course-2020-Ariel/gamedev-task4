using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject camera = GameObject.Find("Main Camera");
        float y_cam = camera.transform.position.y;
        float y_level1 = GameObject.Find("level1platform").transform.position.y + 0.5f;
        float y_level2 = GameObject.Find("level2platform").transform.position.y + 0.5f;
        float y_level3 = GameObject.Find("level3platform").transform.position.y + 0.5f;
        if (y_cam> y_level3)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level3, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level3, collision.gameObject.transform.position.z);
        }
        else if (y_cam > y_level2)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level2, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level2, collision.gameObject.transform.position.z);
        }
        else if (y_cam > y_level1)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level1, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level1, collision.gameObject.transform.position.z);
        }
    }
}
