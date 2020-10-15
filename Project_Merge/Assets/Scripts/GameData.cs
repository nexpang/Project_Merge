using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public long Cheese = 0;
    public long Money = 0;
    public int Upgrade_MoneyElapsedTimeStack = 0;
    public int Upgrade_CheeseStack = 0;

    public List<int> MiceList = new List<int>();
    public List<Vector2> MiceXY = new List<Vector2>();
}