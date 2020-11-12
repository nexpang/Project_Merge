using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStat : Singleton<GameStat>
{
    public List<int> MoneyDataTable = new List<int>();

    public float Upgrade_MoneyElapsedTime { get; private set; } = 4;
    public float feverValue { get; private set; } = 1;
    public bool isFever = false;

    private void Start()
    {
        MoneyDataTableCalculate();
    }
    private void Update()
    {
        FUpgrade_MoneyElapsedTime(SaveMouse.Instance.gameData.Upgrade_MoneyElapsedTimeStack);
    }
    void Awake()
    {
        Screen.SetResolution(1440, 2960, true);
        SaveMouse.Instance.LoadGameData();
    }
    public void FUpgrade_MoneyElapsedTime(int upgradeStack)
    {
        if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value < 0.5)
            Upgrade_MoneyElapsedTime = (4 - (upgradeStack * 0.1f)) * feverValue;
        else
            Upgrade_MoneyElapsedTime = 4 - (upgradeStack * 0.1f);
    }

    public void FeverValueSet(float Value)
    {
        feverValue = Value;
    }

    private void MoneyDataTableCalculate()
    {
        MoneyDataTable[0] = 1;
        MoneyDataTable[1] = 1;
        for (int i = 2; i < 42; i++)
        {
            MoneyDataTable[i] = MoneyDataTable[i - 1] + MoneyDataTable[i - 2];
        }
    }

    public bool MouseCountCheck()
    {
        if(UIManager.Instance.pposition.childCount < SaveMouse.Instance.gameData.Upgrade_MouseLimit )
            return true;
        else
            return false;
    }
}
