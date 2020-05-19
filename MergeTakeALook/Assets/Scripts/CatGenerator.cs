using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatGenerator : MonoBehaviour
{
    public float genGauge= 0.0f;
    public GameObject newCatPrefab;
    public GameObject catSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateCat()
    {
        if (catSlots == null)
        {
            Debug.Log("CatSlot is Empty");
            return;
        }
        Transform transform = catSlots.GetComponent<Transform>();
        foreach (Transform catSlot in transform)
        {
            if (catSlot.childCount == 0)
            {
                GameObject newCat = Instantiate(newCatPrefab, catSlot.position, Quaternion.identity);
                newCat.transform.parent = catSlot;
                return;
            }
        }

        // no empty Slot
        // TODO: print message that no cat slot is available
        Debug.Log("Not enough CatSlot!");
    }
}
