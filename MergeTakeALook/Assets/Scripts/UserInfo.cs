using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static UserInfo singleton = null;

    private long gold;
    private long catnip;
    private long wood;

    public long getGold() { return gold; }
    public long getCatnip() { return catnip; }
    public long getWood() { return wood; }

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

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
