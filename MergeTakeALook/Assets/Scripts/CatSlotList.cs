using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSlotList : MonoBehaviour
{

    private int availableCatSlot = 6;

    private const int maxCatSlot = 9;

    public void unlockCatSlot()
    {
        if (availableCatSlot < maxCatSlot)
        {
            availableCatSlot++;
            transform.GetChild(availableCatSlot - 1).GetComponent<CatSlot>().isMountable = true;
        }
    }
}
