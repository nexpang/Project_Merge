using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Mice
{
    public int ID;

    public Mice(int id)
    {
        ID = id;
    }
}

public class Wealth
{
    public int CHEESE;
    public int MONEY;

    public Wealth(int cheese, int money)
    {
        CHEESE = cheese;
        MONEY = money;
    }
}

public class Upgrade
{
    public int CHEESE;
    public Upgrade(int cheese)
    {
        CHEESE = cheese;
    }
}
public class SaveMouse : MonoBehaviour
{
    public List<Mice> MiceList = new List<Mice>();
    [SerializeField]
    private GameObject pposition = null;

    public List<Wealth> WealthList = new List<Wealth>();

    public List<Upgrade> UpgradeList = new List<Upgrade>();

    private void Awake()
    {
        MiceLoad();
        WealthLoad();
        UpgradeLoad();
        UIManager.Instance.UpdateMoneyCheese();
    }
    void Update()
    {
        MiceSave();// 최적화 없는 업데이트문에 세이브 이거 합치거나 저장할때 되게 하셈 난 귀찮음 ^^
        WealthSave();
        UpgradeSave();
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    MiceSave();
        //}
    }
    void MiceLoad()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/SaveData/MiceData.json");

        JsonData MiceData = JsonMapper.ToObject(Jsonstring);

        for (int i =0; i < MiceData.Count; i++)
        {
            float randomMouseX = Random.Range(-1.8f, 1.8f);
            float randomMouseY = Random.Range(-2.2f, 3f);

            Vector3 randomSpawn = new Vector3(randomMouseX, randomMouseY, 0.1f);

            GameObject mouse = MouseSpriteManager.Instance.TileSprites[(int)MiceData[i]["ID"]];
            GameObject newmouse = Instantiate(mouse, randomSpawn, Quaternion.identity);
            newmouse.transform.SetParent(pposition.transform);
        }

        for (int i = 0; i < MiceList.Count; i++)
        {
            Debug.Log(i + ". : " + MiceList[i].ID + "레벨");
        }

    }
    void MiceSave()
    {
        MiceList.Clear();
        for (int i = 0; i < pposition.transform.childCount; i++)
        {
            int id = pposition.transform.GetChild(i).GetComponent<MouseElement>().mouseID-1;
            MiceList.Add(new Mice(id));
        }

        JsonData MiceJson = JsonMapper.ToJson(MiceList);

        File.WriteAllText(Application.dataPath + "/SaveData/MiceData.json", MiceJson.ToString());
    }
    void WealthSave()
    {
        WealthList.Clear();

        int myCheese = UIManager.Instance.MCheese;
        int myMoney = UIManager.Instance.Mmoney;

        WealthList.Add(new Wealth(myCheese,myMoney));

        JsonData WealthJson = JsonMapper.ToJson(WealthList);

        File.WriteAllText(Application.dataPath + "/SaveData/WealthData.json", WealthJson.ToString());
    }
    void WealthLoad()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/SaveData/WealthData.json");

        JsonData WealthData = JsonMapper.ToObject(Jsonstring);

        UIManager.Instance.MCheese = (int)WealthData[0]["CHEESE"];
        UIManager.Instance.Mmoney = (int)WealthData[0]["MONEY"];
    }
    void UpgradeSave()
    {
        UpgradeList.Clear();

        int upgradeCheese = UIManager.Instance.MCheeseUpgrade;

        UpgradeList.Add(new Upgrade(upgradeCheese));

        JsonData UpgradeJson = JsonMapper.ToJson(UpgradeList);

        File.WriteAllText(Application.dataPath + "/SaveData/UpgradeData.json", UpgradeJson.ToString());
    }
    void UpgradeLoad()
    {
        string Jsonstring = File.ReadAllText(Application.dataPath + "/SaveData/UpgradeData.json");

        JsonData UpgradeData = JsonMapper.ToObject(Jsonstring);

        UIManager.Instance.MCheeseUpgrade = (int)UpgradeData[0]["CHEESE"];
    }
}
