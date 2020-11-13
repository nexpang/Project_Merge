using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemCoolDown : Singleton<GameItemCoolDown>
{
    public GameObject[] ItemCooldown = null;


    public int cleanerCoolDownCurrentSec = 0;
    public int cleanerCoolDownSec = 180;

    public int feverCoolDownCurrentSec = 0;
    public int feverCoolDownSec = 180;

    private void Awake()
    {
        InvokeRepeating("OneSecond",0,1);
        //feverCoolDownCurrentSec = 23;
    }
    void Update()
    {
        cleanerCoolDownSec = SaveMouse.Instance.gameData.Upgrade_CleanerWaitTime;

        feverCoolDownSec = SaveMouse.Instance.gameData.Upgrade_FeverWaitTime;

        GameObject timeBar = ItemCooldown[0];

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

        // =============================================피버=============================================
        GameObject timeBar2 = ItemCooldown[1];

        if (feverCoolDownCurrentSec < (feverCoolDownSec / 10))
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(52, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 2)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(76, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 3)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(100, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 4)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(124, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 5)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(148, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 6)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(172, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 7)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(196, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 8)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(220, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec <= (feverCoolDownSec / 10) * 9)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(244, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec < feverCoolDownSec)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(268, timeBar2.GetComponent<RectTransform>().offsetMin.y);
        else if (feverCoolDownCurrentSec >= feverCoolDownSec)
            timeBar2.GetComponent<RectTransform>().offsetMin = new Vector2(292, timeBar2.GetComponent<RectTransform>().offsetMin.y);
    }

    private void OneSecond()
    {
        if(SaveMouse.Instance.gameData.ItemCleaner == 2)
            cleanerCoolDownCurrentSec++;
        if(SaveMouse.Instance.gameData.ItemFever == 1)
            feverCoolDownCurrentSec++;
    }
}
