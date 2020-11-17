using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;

public class GameItem : Singleton<GameItem>
{
    public List<int> miceCount = new List<int>();

    [HideInInspector]
    public GameObject firstTarget = null;
    [HideInInspector]
    public GameObject secondTarget = null; // 쥔공청소기에 쓰일것들


    public GameObject feverRainbow = null; // 피버 타임에 쓰일것

    private void Start()
    {
        if (SaveMouse.Instance.gameData.ItemFever == 2)
            SaveMouse.Instance.gameData.ItemFever = 1;
    }

    void Update()
    {
        // ============================아이템 공통 업데이트======================
        if (gameObject == GameObject.Find("Items"))
        {
            if (SaveMouse.Instance.gameData.ItemCleaner == 0)
            {
                GameObjectBox.Instance.Items[0].SetActive(false);
            }
            else if (SaveMouse.Instance.gameData.ItemCleaner == 1)
            {
                GameObjectBox.Instance.Items[0].SetActive(true);
                GameObjectBox.Instance.Items[0].GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.ItemCleaner[0];
            }
            else if (SaveMouse.Instance.gameData.ItemCleaner == 2)
            {
                GameObjectBox.Instance.Items[0].SetActive(true);
                GameObjectBox.Instance.Items[0].GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.ItemCleaner[1];
            }


           //=======================피버
            if (GameItemCoolDown.Instance.feverCoolDownCurrentSec >= GameItemCoolDown.Instance.feverCoolDownSec)
                SaveMouse.Instance.gameData.ItemFever = 2;

            if (SaveMouse.Instance.gameData.ItemFever == 0)
            {
                GameObjectBox.Instance.Items[1].SetActive(false);
            }
            else if (SaveMouse.Instance.gameData.ItemFever == 1)
            {
                GameObjectBox.Instance.ItemButtons[0].GetComponent<Animator>().Play("FeverLever_Idle");
                GameObjectBox.Instance.Items[1].SetActive(true);
                GameObjectBox.Instance.Items[1].GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.ItemFever[0];
            }
            else if (SaveMouse.Instance.gameData.ItemFever == 2)
            {
                GameObjectBox.Instance.ItemButtons[0].GetComponent<Animator>().Play("FeverLever_Ready");
                GameObjectBox.Instance.Items[1].SetActive(true);
                GameObjectBox.Instance.Items[1].GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.ItemFever[1];
            }
        }
        // =====================================================================

        // ============================쥔공 청소기===============================
        if (gameObject == GameObjectBox.Instance.Items[0])
        {
            if (SaveMouse.Instance.gameData.ItemCleaner == 2)
            {
                if (GameItemCoolDown.Instance.cleanerCoolDownCurrentSec >= GameItemCoolDown.Instance.cleanerCoolDownSec) // 여기서 0을 하지않고 합치면서 0으로 변경
                {
                    MergeMachineReady();
                }
            }
            else
                GameItemCoolDown.Instance.cleanerCoolDownCurrentSec = 0;
        }
        if (GameStat.Instance.isFever)
        {
            if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value >= 0.5)
            {
                GameObject.Find("FeverTextSprite").GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.FeverHead[1];
                GameObject.Find("FeverTextSprite2").GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.FeverHead[1];
            }
            else
            {
                GameObject.Find("FeverTextSprite").GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.FeverHead[0];
                GameObject.Find("FeverTextSprite2").GetComponent<SpriteRenderer>().sprite = GameSpriteBox.Instance.FeverHead[0];
            }
        }
    }

    public void ClickCleanerButton()
    {
        // ============================쥔공 청소기===============================
        if (gameObject == GameObjectBox.Instance.Items[0])
        {
            if (SaveMouse.Instance.gameData.ItemCleaner == 0)
                GameObjectBox.Instance.Items[0].SetActive(false);
            else if (SaveMouse.Instance.gameData.ItemCleaner == 1)
                SaveMouse.Instance.gameData.ItemCleaner = 2;
            else
                SaveMouse.Instance.gameData.ItemCleaner = 1;
        }
    }

    public void ClickFeverButton()
    {
        if (SaveMouse.Instance.gameData.ItemFever == 0)
            GameObjectBox.Instance.Items[1].SetActive(false);
        if (GameItemCoolDown.Instance.feverCoolDownCurrentSec >= GameItemCoolDown.Instance.feverCoolDownSec)
        {
            if (SaveMouse.Instance.gameData.ItemFever == 2)
            {
                SaveMouse.Instance.gameData.ItemFever = 1;
                ReadyFevertime();
            }
        }
    }

    private void MergeMachineReady()
    {
        GameObject[] mice = GameObject.FindGameObjectsWithTag("Mouse");
        int targetMouseID = 0;

        for (int i = 0; i < miceCount.Count; i++) // 리스트 초기화
        {
            miceCount[i] = 0;
        }

        for (int i = 0; i < mice.Length; i++)  // 현재 쥐들의 단계를 통계로 변환
        {
            for (int j = 1; j < 40; j++)
            {
                if (mice[i].GetComponent<MouseElement>().mouseID == j)
                {
                    miceCount[j - 1]++;
                }
            }
        }

        for (int i = 0; i < 39; i++)  // 2개 이상 있는 쥐 단계 감지, 타겟 설정 -  39로 한이유: 40이 최대단계라
        {
            if (miceCount[i] >= 2)
            {
                targetMouseID = i + 1;
                break;
            }
            if (i == 38) return; // 모든 쥐가 2마리 이상 없으면 리턴
        }

        if (targetMouseID >= MouseBookData.Instance.GetLastMouseID()) // 만약 도감 마지막보다 크다면 리턴
            return;

        if (UIManager.Instance.MouseBookDesc.activeSelf && !UIManager.Instance.MouseBook.activeSelf) // 도감 설명만 켜있으면 리턴
            return;

        for (int i = 0; i < mice.Length; i++) // 최종적으로 오브젝트 선택
        {
            if (mice[i].GetComponent<MouseElement>().mouseID == targetMouseID)
            {
                if (mice[i] != firstTarget && firstTarget == null)
                    firstTarget = mice[i];
                else if (mice[i] != firstTarget)
                    secondTarget = mice[i];
            }
        }

        firstTarget.transform.SetParent(UIManager.Instance.pposition.transform.parent);
        secondTarget.transform.SetParent(UIManager.Instance.pposition.transform.parent);

        if (firstTarget == null || secondTarget == null) // 예외 처리 : 타겟이 없어졌다면 리턴
            return;

        firstTarget.GetComponent<Rigidbody2D>().simulated = false;
        firstTarget.GetComponent<MouseElement>().MoveWithComputerMouse = false;
        secondTarget.GetComponent<Rigidbody2D>().simulated = false;
        secondTarget.GetComponent<MouseElement>().MoveWithComputerMouse = false;


        //==============================본격적인 합치기 시작==============================

        firstTarget.transform.DOMove(new Vector2(1,-2.25f), 0.75f);
        secondTarget.transform.DOMove(new Vector2(1,-2.25f), 0.75f);
        Invoke("MergeMachineLaunch", 1);
        GameItemCoolDown.Instance.cleanerCoolDownCurrentSec = 0;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void MergeMachineLaunch() // 쥔공청소기 본격적인 합치기
    {
        if (firstTarget == null || secondTarget == null) // 예외 처리 : 타겟이 없어졌다면 리턴
        {
            if (firstTarget == null && secondTarget != null)
                secondTarget.GetComponent<Rigidbody2D>().simulated = true;
            if (firstTarget != null && secondTarget == null)
                firstTarget.GetComponent<Rigidbody2D>().simulated = true;
            return;
        }
        Vector3 spawnPoint = new Vector3(1, -2.25f, 0.1f);
        GameObject newMouse = Instantiate(MouseSpriteManager.Instance.TileSprites[firstTarget.GetComponent<MouseElement>().mouseID], spawnPoint, Quaternion.identity);
        newMouse.transform.SetParent(UIManager.Instance.pposition.transform);
        float randomMouseX = Random.Range(-1.8f, 1.8f);
        float randomMouseY = Random.Range(-2.2f, 1.8f);
        newMouse.transform.DOMove(new Vector2(randomMouseX, randomMouseY),1);

        firstTarget.transform.DOMove(new Vector2(firstTarget.transform.position.x, firstTarget.transform.position.y), 0);       
        secondTarget.transform.DOMove(new Vector2(firstTarget.transform.position.x, firstTarget.transform.position.y), 0);
        firstTarget.SetActive(false);
        secondTarget.SetActive(false);
        FunctionManager.Instance.TimeDestroy(firstTarget, 1);
        FunctionManager.Instance.TimeDestroy(secondTarget, 1);
        transform.GetChild(0).gameObject.SetActive(false);
    }
    //==============================피버 타임==============================

    private void ReadyFevertime()
    {
        Invoke("StartFevertime", 1f);
        //Invoke("StopFevertime", 10f);// 지속시간

        //Invoke("ActiveFevertime", feverTimeCooltime); //쿨타임 스크립트로 해야됨
        AudioManager.Instance.MusicDefaultTotal.Stop();
        GameItemCoolDown.Instance.cleanerCoolDownCurrentSec = 0;
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void StartFevertime()
    {
        feverRainbow.SetActive(true);
        GameItemCoolDown.Instance.feverCoolDownCurrentSec = 0;
        GameStat.Instance.FeverValueSet(0.2f);
        SaveMouse.Instance.gameData.ItemFever = 1;
        GameStat.Instance.isFever = true;

        Invoke("StopFevertime", 10f);// 지속시간
    }
    private void StopFevertime()
    {
        GameStat.Instance.FeverValueSet(1f);
        GameStat.Instance.isFever = false;
        AudioManager.Instance.MusicDefaultTotal.Play();
        feverRainbow.SetActive(false);
    }
}