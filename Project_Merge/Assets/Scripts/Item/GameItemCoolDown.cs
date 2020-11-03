using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemCoolDown : Singleton<GameItemCoolDown>
{
    public int cleanerCoolDownCurrentSec = 0;
    public int cleanerCoolDownSec = 180;

    private void Awake()
    {
        InvokeRepeating("OneSecond",0,1);
    }
    void Update()
    {
        cleanerCoolDownSec = SaveMouse.Instance.gameData.Upgrade_CleanerWaitTime;


        if(gameObject == GameObjectBox.Instance.ItemCooldown[0]) // 쥔공청소기
        {
            GameObject timeBar = GameObjectBox.Instance.ItemCooldown[0];

            if (cleanerCoolDownCurrentSec < (cleanerCoolDownSec / 10))
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1008, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 2)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1032, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 3)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1056, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 4)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1080, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 5)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1104, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 6)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1128, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 7)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1152, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 8)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1176, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= (cleanerCoolDownSec / 10) * 9)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1200, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec <= cleanerCoolDownSec)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1224, timeBar.GetComponent<RectTransform>().offsetMin.y);
            else if (cleanerCoolDownCurrentSec > cleanerCoolDownSec)
                timeBar.GetComponent<RectTransform>().offsetMin = new Vector2(1248, timeBar.GetComponent<RectTransform>().offsetMin.y);
        }
    }

    private void OneSecond()
    {
        cleanerCoolDownCurrentSec++;
    }
}
