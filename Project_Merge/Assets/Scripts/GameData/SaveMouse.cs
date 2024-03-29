﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveMouse : MonoBehaviour
{
    //싱글톤====================
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static SaveMouse _instance;
    public static SaveMouse Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "SaveMouse";
                _instance = _container.AddComponent(typeof(SaveMouse)) as SaveMouse;
                DontDestroyOnLoad(_container);
            }
            return _instance;
        }
    }
    // =================================================

    public string GameDataFileName = ".json";

    private string filePath = "";

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if (_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }
    private void Awake()
    {
        filePath = string.Concat(Application.persistentDataPath, GameDataFileName);
        Debug.Log(filePath);
    }

    public void LoadGameData()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기");
            string code = File.ReadAllText(filePath);

            byte[] bytes = System.Convert.FromBase64String(code);
            string FromJsonData = System.Text.Encoding.UTF8.GetString(bytes);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
        MiceLoad();
        UIManager.Instance.UpdateMoneyCheese();
    }

    public void SaveGameData()
    {
        MiceSave();
        string ToJsonData = JsonUtility.ToJson(gameData, true);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(ToJsonData);
        string code = System.Convert.ToBase64String(bytes);

        File.WriteAllText(filePath, code);
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    private void OnApplicationPause()
    {
        SaveGameData();
    }

    public void MiceLoad()
    {
        if (gameData.TutorialStage != -1 && gameData.TutorialStage != 0)
        {
            gameData.MiceList.Clear();
            gameData.MiceXY.Clear();
            return;
        }

        for (int i = 0; i < gameData.MiceList.Count; i++)
        {
            GameObject newmouse = Instantiate(MouseSpriteManager.Instance.TileSprites[gameData.MiceList[i]-1], gameData.MiceXY[i], Quaternion.identity);
            GameObject pposition = GameObject.Find("pposition");
            newmouse.transform.SetParent(pposition.transform);
        }
    }
    public void MiceSave()  // 게임 저장시, 합쳐질 때 저장 됨
    {
        gameData.MiceList.Clear();
        gameData.MiceXY.Clear();
        GameObject pposition = GameObject.Find("pposition");

        for (int i = 0; i < pposition.transform.childCount; i++)
        {
            gameData.MiceList.Add(pposition.transform.GetChild(i).gameObject.GetComponent<MouseElement>().mouseID);
            gameData.MiceXY.Add(pposition.transform.GetChild(i).gameObject.transform.localPosition);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            MiceSave();
        }
        if (Input.GetKey(KeyCode.L))
        {
            MiceLoad();
        }
    }

    private void Start()
    {
        InvokeRepeating("AutoSave", 0, 30);

    }
    private void AutoSave()
    {
        SaveGameData();
        Debug.Log("Save Complete");
    }
}
