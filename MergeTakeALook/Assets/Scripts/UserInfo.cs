using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{

    private long gold;
    private long catnip;
    private long wood;

    public long getGold() { return gold; }
    public long getCatnip() { return catnip; }
    public long getWood() { return wood; }

    // Start is called before the first frame update
    void Start()
    {
        // bring numbers from save file
        gold = 0;
        catnip = 1000;
        wood = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
