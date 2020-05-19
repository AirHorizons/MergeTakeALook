using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSlot : MonoBehaviour
{

    private bool isCatMounted;

    // Start is called before the first frame update
    void Start()
    {
        isCatMounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        isCatMounted = (gameObject.transform.childCount > 0); 
    }
}
