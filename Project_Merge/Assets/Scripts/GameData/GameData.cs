using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    [Header("화폐(구)")]
    public long Cheese = 0;
    public long Money = 0;
    public long JewelryMoney = 0;

    // 데이터 은닉 때문에 JewelryMoney 데이터가 삭제되는 오류 발생, 그러므로 New 00을 만들어서 복구했음
    // 앞으로도 이렇게 복구해야한다면 _01, _02같이 추가바람
    [Header("화폐(신)")]
    [SerializeField]
    private long New_Cheese_00 = 0;
    [SerializeField]
    private long New_Money_00 = 0;
    [SerializeField]
    private long New_JewelryMoney_00 = 0;


    // 딱한번만 복구되게 bool문 추가했는데 이것도 후에 또 복구할 일이 생기면 이름을 바꿔야하고, 다른 화폐가 복구가 필요하면 bool 변수를 추가할것
    [Header("복구 이미 했나?")]
    [SerializeField]
    private bool isRepaired = false;



    [Header("업그레이드 데이터")]
    public int Upgrade_MoneyElapsedTimeStack = 0;
    public int Upgrade_CheeseStack = 0;
    public int Upgrade_MouseLimit = 8;

    public int Upgrade_CleanerWaitTime = 200;
    public int Upgrade_CleanerWaitTimeStack = 0;
    public int ItemCleaner = 0; // 0이면 없음, 1이면 off, 2이면 on

    public int Upgrade_FeverWaitTime = 300;
    public int Upgrade_FeverWaitTimeStack = 0;
    public int ItemFever = 0; // 0이면 없음, 1이면 준비중, 2면 준비완료

    public int Upgrade_Background1 = 0;
    public int Upgrade_Background2 = 0;
    public int Upgrade_Background3 = 0;

    public int currentBackground = 0; // 0 - 기본배경, 1 - 쥐평선, 2 - 노을, 3 - 쥐리산

    [Header("튜토리얼 세이브")]
    public int TutorialStage = 0;

    [Header("쥐 리스트/좌표")]
    public List<int> MiceList = new List<int>();
    public List<Vector2> MiceXY = new List<Vector2>();

    public enum SETTYPE
    {
        SET,
        ADD,
        REMOVE,
    };

    public void AccessSetJewelry(SETTYPE settype,long value)
    {
        switch(settype)
        {
            case SETTYPE.SET: New_JewelryMoney_00 = value; break;
            case SETTYPE.ADD: New_JewelryMoney_00 += value; break;
            case SETTYPE.REMOVE: New_JewelryMoney_00 -= value; break;
        }
    }

    public long AccessGetJewelry()
    {
        return New_JewelryMoney_00;
    }

    public void AccessSetCheese(SETTYPE settype, long value)
    {
        switch (settype)
        {
            case SETTYPE.SET: New_Cheese_00 = value; break;
            case SETTYPE.ADD: New_Cheese_00 += value; break;
            case SETTYPE.REMOVE: New_Cheese_00 -= value; break;
        }
    }

    public long AccessGetCheese()
    {
        return New_Cheese_00;
    }

    public void AccessSetMoney(SETTYPE settype, long value)
    {
        switch (settype)
        {
            case SETTYPE.SET: New_Money_00 = value; break;
            case SETTYPE.ADD: New_Money_00 += value; break;
            case SETTYPE.REMOVE: New_Money_00 -= value; break;
        }
    }
    public long AccessGetMoney()
    {
        return New_Money_00;
    }

    public void AccessRepairBoolJM(bool value)
    {
        isRepaired = value;
    }

    public bool AccessRepairBoolJMGet()
    {
        return isRepaired;
    }
}