using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CatGenerator : MonoBehaviour
{
    private int genGauge = 200;
    private int maxGauge = 500;
    private int gaugeSpeed = 20;
    private int gaugeChargeRate = 10;
    private int gaugeClickrate = 10;
    public GameObject newCatPrefab;
    public GameObject catSlots;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("chargeGauge", 0.1f, 0.1f);
    }

    

    void chargeGauge()
    {
        if (genGauge < maxGauge)
        {
            if (maxGauge - genGauge > gaugeSpeed / gaugeChargeRate)
                genGauge += gaugeSpeed / gaugeChargeRate;
            else
                genGauge = maxGauge;
        }
        // Debug.Log(genGauge);
    }

    public void GenerateCat()
    {
        if (catSlots == null)
        {
            Debug.Log("CatSlot is Null");
            return;
        }
        if (genGauge >= 100)
        {
            Debug.Log("GenCat");
            Transform transform = catSlots.GetComponent<Transform>();
            foreach (Transform catSlot in transform)
            {
                if (catSlot.childCount == 0)
                {
                    GameObject newCat = Instantiate(newCatPrefab, catSlot.position, Quaternion.identity);
                    newCat.transform.parent = catSlot;
                    genGauge -= 100;
                    return;
                }
            }
            // no empty Slot
            // TODO: print message that no cat slot is available
            Debug.Log("Not enough CatSlot!");
            
            
        }
        if (genGauge < maxGauge)
        {
            if (maxGauge - genGauge > gaugeClickrate)
                genGauge += gaugeClickrate;
            else
                genGauge = maxGauge;
        }
    }

    public int getGenGauge() { return genGauge; }
    public int getMaxGauge() { return maxGauge; }
}
