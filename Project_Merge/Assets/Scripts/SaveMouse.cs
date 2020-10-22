using System.Collections;
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
            if(!_instance)
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

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if(File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            _gameData = new GameData();
        }
        MiceLoad();
        UIManager.Instance.UpdateMoneyCheese();
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        MiceSave();
        MiceXYSave();
    }

    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    public void MiceLoad()
    {
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

    public void MiceXYSave() // 쥐를 클릭하고 마우스를 올렸을 때 저장됨
    {
        gameData.MiceXY.Clear();
        GameObject pposition = GameObject.Find("pposition");

        for (int i = 0; i < pposition.transform.childCount; i++)
        {
            gameData.MiceXY.Add(pposition.transform.GetChild(i).gameObject.transform.localPosition);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.S))
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
