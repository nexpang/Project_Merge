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

public class SaveMouse : MonoBehaviour
{
    public List<Mice> MiceList = new List<Mice>();
    [SerializeField]
    private GameObject pposition = null;
    private void Awake()
    {
        MiceLoad();
    }
    void Update()
    {
        MiceSave();// 최적화 없는 업데이트문에 세이브 이거 합치거나 저장할때 되게 하셈 난 귀찮음 ^^
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
}
