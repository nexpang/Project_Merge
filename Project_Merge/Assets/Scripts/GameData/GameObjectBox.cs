﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectBox : Singleton<GameObjectBox>
{
    public GameObject CheeseAnimation = null;
    public GameObject CoinAnimation = null;
    public GameObject CatClickAnimation = null;

    [Header("아이템")]
    public GameObject[] Items = null;
    public GameObject[] ItemCooldown = null;

    [Header("아이템 이펙트")]
    public GameObject CleanerWind = null;
}