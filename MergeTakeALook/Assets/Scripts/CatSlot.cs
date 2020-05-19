using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSlot : MonoBehaviour
{
    public Sprite mountedBox;
    public Sprite unmountedBox;

    public bool isCatMounted { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isCatMounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        isCatMounted = (gameObject.transform.childCount > 0);
        if (isCatMounted) GetComponent<SpriteRenderer>().sprite = mountedBox;
        else GetComponent<SpriteRenderer>().sprite = unmountedBox;
    }
}
