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
    public void setGold(long g) { gold = g; }
    public long getCatnip() { return catnip; }
    public void setCatnip(long c) { catnip = c; }
    public long getWood() { return wood; }
    public void setWood(long w) { wood = w; }

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
}
