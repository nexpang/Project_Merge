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
    public Transform pposition = null;

    public bool isBGon = false;
    public bool isBGoff = false;

    public GameObject Gmarket = null;
    public GameObject Catbackground = null;
    public GameObject Gbackground = null;

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
        if(isBGon ? false : MCheese > NeedCheese)
        {
            MCheese -= NeedCheese;
            GameObject newmouse = Instantiate(mouse,pposition.position ,Quaternion.identity);
            newmouse.transform.SetParent(pposition.transform);

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
    public void BGMove()
    {
        if (Catbackground.activeSelf)
        {
            //Time.timeScale = 1; //시간 정상
            StartCoroutine(BGoff());
        }
        else
        {
            StartCoroutine(BGon());

            //Time.timeScale = 0; //시간 멈춤
        }
    }
    private IEnumerator BGon()
    {
        if(isBGon == false)
        {
            Catbackground.transform.DOMoveX(0, 1);
            isBGon = true;
            Catbackground.SetActive(true);
            Gbackground.SetActive(false);
            yield return new WaitForSeconds(1f);
            isBGon = false;
        }
    }
    private IEnumerator BGoff()
    {
        if(isBGoff == false)
        {
            Catbackground.transform.DOMoveX(-5, 1f);
            isBGoff = true;
            Gbackground.SetActive(true);
            yield return new WaitForSeconds(1f);
            Catbackground.SetActive(false);
            yield return new WaitForSeconds(1f);
            isBGoff = false;
        }
    }
    public void CheeseCat()
    {
        MCheese++;
        UpdateMoneyCheese();
    }
}
