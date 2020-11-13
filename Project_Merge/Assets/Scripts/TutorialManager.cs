using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TutorialFinger = null;
    [SerializeField]
    private GameObject TutorialLore = null;

    [SerializeField]
    private Sprite TutorialFingerPointSprite = null;

    [SerializeField]
    private GameObject[] TutorialBlocks = null;

    private float pointSpeed = 2f;

    private void Awake()
    {
        //Invoke("NewbieDetect", 0.3f);
        NewbieDetect();
    }

    private void NewbieDetect()
    {
        if(SaveMouse.Instance.gameData.Cheese == 0 && SaveMouse.Instance.gameData.Money == 0 && UIManager.Instance.pposition.childCount == 0)
        {
            SaveMouse.Instance.gameData.TutorialStage = 1;
        }
        else if(SaveMouse.Instance.gameData.TutorialStage > 0)
        {
            // 튜토리얼을 진행하시겠습니까? 띄우고 안하면 -1로 바꿈, 하면 1로 바꿔
            SaveMouse.Instance.gameData.TutorialStage = 1; // 근데 일단 1로 바꿔놔 지금은 귀찮거든
            SaveMouse.Instance.gameData.Cheese = 0;
            SaveMouse.Instance.gameData.Money = 0;
            SaveMouse.Instance.gameData.Upgrade_MouseLimit = 8;
            MarketManager.Instance.MouseList[1].upgradeCount = 0;
            // 쥐도 로드 안되게 해놨음
        }
        else // 만약 튜토리얼 조건 충족 안되면
        {
            TutorialFinger.SetActive(false); // 할필요없음 ㅋ
        }
    }

    private void Update()
    {
        // ==========튜토리얼 스테이지 1==================================
        if (SaveMouse.Instance.gameData.TutorialStage == 1)
        {
            TutorialLore.SetActive(true);
            TutorialFinger.SetActive(true);
            TutorialBlocks[0].SetActive(true);
            TutorialBlocks[5].SetActive(true);
            TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage1_0");

            if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value >= 0.5 && Input.GetMouseButtonUp(0))
            {
                SaveMouse.Instance.gameData.TutorialStage = 2;
                TutorialFinger.transform.localPosition = new Vector2(-2, -3.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[0].SetActive(false);
                TutorialBlocks[5].SetActive(false);
            }
        }
        // ==========튜토리얼 스테이지 2==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 2)
        {
            TutorialBlocks[1].SetActive(true);
            TutorialBlocks[2].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(0, 0.23f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "잘했쥐! 이제 고양이를 클릭해서 \n 치즈를 20개 벌어보라쥐!";
            }

            if (SaveMouse.Instance.gameData.Cheese >= 20)
            {
                SaveMouse.Instance.gameData.TutorialStage = 3;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[1].SetActive(false);
                TutorialBlocks[2].SetActive(false);
            }
        }
        // ==========튜토리얼 스테이지 3==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 3)
        {
            TutorialBlocks[0].SetActive(true);
            TutorialBlocks[5].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(2, -3.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage3_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "훌륭하쥐! 이제 슬금슬금 조심히 \n 돌아가보쥐! 스크롤을 드래그해서 \n 다시 오른쪽으로 돌아와봐쥐!";
            }

            if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value < 0.5 && Input.GetMouseButtonUp(0))
            {
                SaveMouse.Instance.gameData.TutorialStage = 4;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[0].SetActive(false);
                TutorialBlocks[5].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 4==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 4)
        {
            TutorialBlocks[3].SetActive(true);
            TutorialBlocks[4].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(0, -4.55f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0"); // 4지만 2의 애니메이션 사용
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "이번엔 쥐들을 불러와보쥐! \n 하단의 버튼을 클릭하여 \n 쥐들을 불러와봐쥐! 치즈가 소모된다쥐.";
            }

            if (UIManager.Instance.pposition.childCount == 1 && MouseBookData.Instance.GetLastMouseID() == 1)
            {
                if(UIManager.Instance.isUIon==false)
                {
                    TutorialFinger.transform.localPosition = new Vector2(0, -4.55f);
                }
                else
                {
                    TutorialFinger.transform.localPosition = new Vector2(0, -3.1f);
                }
            }

            if (UIManager.Instance.pposition.childCount >= 2)
            {
                SaveMouse.Instance.gameData.TutorialStage = 5;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[3].SetActive(false);
                TutorialBlocks[4].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 5==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 5)
        {
            TutorialBlocks[1].SetActive(true);
            TutorialBlocks[2].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                MousesSelect();
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "쥐가 두 마리 생겼쥐! \n 쥐 한 마리를 다른 한 마리로 드래그 해서 \n 쥐를 합쳐보쥐!";
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            }
            if(TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled == false && mouse1 != null && mouse2 != null)
            {
                pointSpeed = Mathf.Lerp(pointSpeed, 50, 0.05f * Time.deltaTime);
                TutorialFinger.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = TutorialFingerPointSprite;
                TutorialFinger.transform.localPosition = Vector2.Lerp(TutorialFinger.transform.localPosition, new Vector2(mouse2.transform.localPosition.x, mouse2.transform.localPosition.y), pointSpeed * Time.deltaTime);
                if (Vector2.Distance(TutorialFinger.transform.localPosition, mouse2.transform.localPosition) <= 0.05f)
                {
                    TutorialFinger.transform.localPosition = mouse1.transform.localPosition;
                    pointSpeed = 2;
                }
            }

            if (UIManager.Instance.pposition.childCount == 1 && MouseBookData.Instance.GetLastMouseID() == 2)
            {
                if (UIManager.Instance.isUIon == false)
                {
                    SaveMouse.Instance.gameData.TutorialStage = 6;
                    TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
                    TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                    TutorialBlocks[1].SetActive(false);
                    TutorialBlocks[2].SetActive(false);
                }
                else
                {
                    TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = true;
                    TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                    TutorialFinger.transform.localPosition = new Vector2(0, -3.1f);
                    TutorialBlocks[1].SetActive(false);
                    TutorialBlocks[2].SetActive(false);
                }
            }

        }
        // ==========튜토리얼 스테이지 6==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 6)
        {
            TutorialBlocks[6].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector3(-2.29f, 2.88f,-0.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "엄청나쥐! 쥐들은 일정 시간마다 \n 돈을 벌쥐. 돈을 줄테니 \n 상점에 들어가보라쥐!";
            }

            if (UIManager.Instance.Gmarket.activeSelf)
            {
                SaveMouse.Instance.gameData.TutorialStage = 7;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[6].SetActive(false);
                TutorialBlocks[7].SetActive(true);
            }
        }

        // ==========튜토리얼 스테이지 7==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 7)
        {
            TutorialBlocks[8].SetActive(true);
            TutorialBlocks[9].SetActive(true);
            TutorialBlocks[10].SetActive(true);
            TutorialBlocks[11].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialBlocks[7].SetActive(false);
                TutorialFinger.transform.localPosition = new Vector3(-0.42f, 2.59f,-0.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "여긴 업그레이드에 필요한 상품을 파는 곳이쥐. \n 가운데 쥐 탭에 들어가보라쥐.";
                TutorialLore.GetComponent<RectTransform>().anchoredPosition = new Vector2(22,-537);
            }

            if (UIManager.Instance.MouseShop.activeSelf)
            {
                SaveMouse.Instance.gameData.TutorialStage = 8;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[11].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 8==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 8)
        {

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector3(1.17f, 1.44f, -0.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "이곳에서 한번 두번째 탭의 상품을 사보라쥐! \n 돈은 내가 넣어줬쥐. 잘 쓰라쥐!";
                SaveMouse.Instance.gameData.Money = 100;
                UIManager.Instance.UpdateMoneyCheese();
            }

            if (MarketManager.Instance.MouseList[1].upgradeCount ==1)
            {
                SaveMouse.Instance.gameData.TutorialStage = 9;
                SaveMouse.Instance.gameData.Money -= 100;
                UIManager.Instance.UpdateMoneyCheese();
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[8].SetActive(false);
                TutorialBlocks[9].SetActive(false);
                TutorialBlocks[10].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 9==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 9)
        {
            TutorialBlocks[12].SetActive(true);
            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector3(2.08f, 4.51f, -0.5f);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "잘했쥐! \n 이런식으로 돈을 주고 좀 더 빠르게 쥐들을 \n 합칠 수 있쥐. 이제 나가보쥐!";
            }

            if (!UIManager.Instance.Gmarket.activeSelf)
            {
                SaveMouse.Instance.gameData.TutorialStage = 10;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[12].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 10==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 10)
        {
            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.SetActive(false);
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "다 끝났쥐! \n 이제 직접 쥐들을 만들어봐라쥐! \n 튜토리얼은 여기까지쥐!";
                TutorialLore.GetComponent<RectTransform>().anchoredPosition = new Vector2(22, 772);
                Invoke("TutorialComplete", 5f);
            }
        }
    }

    private bool isTrigger = false;
    private GameObject mouse1 = null;
    private GameObject mouse2 = null;
    private void MousesSelect()
    {
        if(isTrigger == false)
        {
            isTrigger = true;
            GameObject[] mice = GameObject.FindGameObjectsWithTag("Mouse");
            mouse1 = mice[0];
            mouse2 = mice[1];
            TutorialFinger.transform.localPosition = mouse1.transform.localPosition;
            Debug.Log(mouse1  + " " + mouse2);
        }
    }


    void TutorialComplete()
    {
        TutorialLore.SetActive(false);
        SaveMouse.Instance.gameData.TutorialStage = -1;
        SaveMouse.Instance.SaveGameData();
    }
}
