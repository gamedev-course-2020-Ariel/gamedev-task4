using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject trackObject;
    [SerializeField] GameObject level1 ;
    [SerializeField] GameObject level2;
    [SerializeField] GameObject level3;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if(Math.Abs(trackObject.transform.position.y - level1.transform.position.y) > 2)
        {
            Vector3 height = new Vector3(0, 0.5f * Time.deltaTime, 0);
            this.transform.position += height;
        }
        if (Math.Abs(trackObject.transform.position.y - level1.transform.position.y) < 2)
        {
            GameObject.Find("Text").GetComponent<TextMeshProUGUI>().text = "Level 1";
        }
        if (Math.Abs(trackObject.transform.position.y - level2.transform.position.y) < 2)
        {
            GameObject.Find("Text").GetComponent<TextMeshProUGUI>().text = "Level 2";
        }
        if (Math.Abs(trackObject.transform.position.y - level3.transform.position.y) < 2)
        {
            GameObject.Find("Text").GetComponent<TextMeshProUGUI>().text = "Level 3";
        }
    }
}
