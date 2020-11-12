using System;
using System.Collections.Generic;
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
    public int Upgrade_MouseLimit = 8;

    public int Upgrade_CleanerWaitTime = 200;
    public int Upgrade_CleanerWaitTimeStack = 0;
    public int ItemCleaner = 0; // 0이면 없음, 1이면 off, 2이면 on

    public int Upgrade_FeverWaitTime = 300;
    public int Upgrade_FeverWaitTimeStack = 0;
    public int ItemFever = 0; // 0이면 없음, 1이면 쿨타임, 2면 on, 3이면 피버 가동중
    

    public int Upgrade_Background1 = 0;
    public int Upgrade_Background2 = 0;
    public int Upgrade_Background3 = 0;

    public int currentBackground = 0; // 0 - 기본배경, 1 - 쥐평선, 2 - 노을, 3 - 쥐리산

    [Header("튜토리얼 세이브")]
    public int TutorialStage = 0;

    [Header("쥐 리스트/좌표")]
    public List<int> MiceList = new List<int>();
    public List<Vector2> MiceXY = new List<Vector2>();
}