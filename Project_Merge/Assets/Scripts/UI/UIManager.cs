using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.VersionControl;
using Microsoft.Win32.SafeHandles;
using DG.Tweening;


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

    public GameObject Gmarket = null;
    public GameObject background = null;

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
    public void GmarketOpen()
    {
        if (Gmarket.activeSelf)
        {
            //Time.timeScale = 1; //시간 정상
            Gmarket.SetActive(false);
        }
        else
        {
            Gmarket.SetActive(true);
            //Time.timeScale = 0; //시간 멈춤
        }
    } //쥐마켓페이지올리기
    public void GmarketClose()
    {
        Gmarket.SetActive(false);
    }
    public void CameraMove()
    {
        background.transform.DOMoveX(-5, 1);
    }
}
