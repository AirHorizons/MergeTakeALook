using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    public GameObject gaugeButton;

    // Update is called once per frame
    void Update()
    {
        CatGenerator cg = gaugeButton.GetComponent<CatGenerator>();
        int genGauge = cg.getGenGauge();
        if (genGauge == cg.getMaxGauge())
            GetComponent<Slider>().value = 1f;
        else
            GetComponent<Slider>().value = (float)(genGauge % 100) / 100;
    }
}
