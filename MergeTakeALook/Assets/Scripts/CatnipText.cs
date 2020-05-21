using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatnipText : MonoBehaviour
{
    private UserInfo userInfo;

    // Start is called before the first frame update
    void Start()
    {
        userInfo = GameObject.Find("UserInfo").GetComponent<UserInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: make this handle more digits with alphabet (ex: 746a)
        GetComponent<Text>().text = userInfo.getCatnip().ToString();
    }
}
