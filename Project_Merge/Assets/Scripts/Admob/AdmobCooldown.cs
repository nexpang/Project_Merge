using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdmobCooldown : Singleton<AdmobCooldown>
{
    public GameObject[] ADCooldown = null;

    public int give5_CoolDownCurrentSec = 0;

    public GameObject rewardAd = null;

    private void Awake()
    {
        InvokeRepeating("OneSecond", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(give5_CoolDownCurrentSec >= 300)
        {
            rewardAd.SetActive(true);
        }
    }
    public void NoAd()
    {
        give5_CoolDownCurrentSec = 0;
        rewardAd.SetActive(false);
    }
    private void OneSecond()
    {
        give5_CoolDownCurrentSec++;
    }
}
