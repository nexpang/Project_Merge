using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.VersionControl;
using Microsoft.Win32.SafeHandles;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text Cheese = null;
    [SerializeField]
    private Text Money = null;
    [SerializeField]
    private int NeedCheese = 0;
    [SerializeField]
    private int MCheese = 0;
    [SerializeField]
    private int Mmoney = 0;
    [SerializeField]
    private int mouseID = 0;
    [SerializeField]
    private GameObject mouse = null;
    [SerializeField]
    private Transform pposition = null;

    MouseSpriteManager MSM;
    GameObject triggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpreadCheese()
    {
        if(MCheese > NeedCheese)
        {
            MCheese -= NeedCheese;
            Instantiate(mouse,pposition.position, Quaternion.identity);
            UpdateMoneyCheese();
        }
        else
        {
            
        }
    }
    private void UpdateMoneyCheese()
    {
        Money.text = Mmoney.ToString();
        Cheese.text = MCheese.ToString();
    }
}
