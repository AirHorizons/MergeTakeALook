using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSlot : MonoBehaviour
{
    public Sprite mountableBox;
    public Sprite unmountableBox;

    public bool isMountable { get; set; }
    public bool isCatMounted { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isCatMounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMountable) GetComponent<SpriteRenderer>().sprite = mountableBox;
        else GetComponent<SpriteRenderer>().sprite = unmountableBox;
    }
}
