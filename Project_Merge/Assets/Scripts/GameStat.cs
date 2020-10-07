using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : Singleton<GameStat>
{
    public List<int> MoneyDataTable = new List<int>();

    public float Upgrade_MoneyElapsedTime { get; private set; } = 4;

    private void Start()
    {
        MoneyDataTableCalculate();
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
}
