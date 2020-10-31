using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class GameData
{
    [Header("화폐")]
    public long Cheese = 0;
    public long Money = 0;
    public long JewelryMoney = 0;

    [Header("업그레이드 데이터")]
    public int Upgrade_MoneyElapsedTimeStack = 0;
    public int Upgrade_CheeseStack = 0;

    public int Upgrade_Background1 = 0;
    public int Upgrade_Background2 = 0;
    public int Upgrade_Background3 = 0;

    public int currentBackground = 0; // 0 - 기본배경, 1 - 쥐평선, 2 - 노을, 3 - 쥐리산
    public int ItemCleaner = 0; // 0이면 없음, 1이면 off, 2이면 on

    [Header("쥐 리스트/좌표")]
    public List<int> MiceList = new List<int>();
    public List<Vector2> MiceXY = new List<Vector2>();
}