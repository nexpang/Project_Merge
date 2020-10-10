using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : Singleton<GameStat>
{
    public List<int> MoneyDataTable = new List<int>();
    public List<int> CheeseDataTable = new List<int>();

    public float Upgrade_MoneyElapsedTime { get; private set; } = 4;

    private void Start()
    {
        MoneyDataTableCalculate();
        CheeseDataTableCalculate();
    }
    void Awake()
    {
        Screen.SetResolution(1440, 2960, false);
    }
    public void FUpgrade_MoneyElapsedTime(int upgradeStack)
    {
        Upgrade_MoneyElapsedTime = 4 - (upgradeStack * 0.1f);
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
    private void CheeseDataTableCalculate()
    {
        CheeseDataTable[0] = 1;
        CheeseDataTable[1] = 1;
        for (int i = 2; i < 31; i++)
        {
            CheeseDataTable[i] = CheeseDataTable[i - 1] + CheeseDataTable[i - 2];
        }
    }
}
