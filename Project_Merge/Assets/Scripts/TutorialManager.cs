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

    private void Start()
    {
        Invoke("NewbieDetect", 0.3f);
    }

    private void NewbieDetect()
    {
        if(SaveMouse.Instance.gameData.Cheese == 0 && SaveMouse.Instance.gameData.Money == 0 && UIManager.Instance.pposition.childCount == 0)
        {
            SaveMouse.Instance.gameData.TutorialStage = 1;
        }
        else if(SaveMouse.Instance.gameData.TutorialStage != -1)
        {
            // 튜토리얼을 진행하시겠습니까? 띄우고 안하면 -1로 바꿈, 하면 1로 바꿔
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
            TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage1_0");

            if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value >= 0.5 && Input.GetMouseButtonUp(0))
            {
                SaveMouse.Instance.gameData.TutorialStage = 2;
                TutorialFinger.transform.localPosition = new Vector2(-556, -1221);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[0].SetActive(false);
            }
        }
        // ==========튜토리얼 스테이지 2==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 2)
        {
            TutorialBlocks[1].SetActive(true);
            TutorialBlocks[2].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(22, 28);
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

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(629, -1221);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage3_0");
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "훌륭하쥐! 이제 슬금슬금 조심히 \n 돌아가보쥐! 스크롤을 드래그해서 \n 다시 오른쪽으로 돌아와봐쥐!";
            }

            if (GameObject.Find("ChangeScroll").GetComponent<Scrollbar>().value < 0.5 && Input.GetMouseButtonUp(0))
            {
                SaveMouse.Instance.gameData.TutorialStage = 4;
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                TutorialBlocks[0].SetActive(false);
            }
        }

        // ==========튜토리얼 스테이지 4==================================
        else if (SaveMouse.Instance.gameData.TutorialStage == 4)
        {
            TutorialBlocks[3].SetActive(true);
            TutorialBlocks[4].SetActive(true);

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialFinger.transform.localPosition = new Vector2(22, -1557);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Stage2_0"); // 4지만 2의 애니메이션 사용
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "이번엔 쥐들을 불러와보쥐! \n 하단의 버튼을 클릭하여 \n 쥐들을 불러와봐쥐! 치즈가 소모된다쥐.";
            }

            if (UIManager.Instance.pposition.childCount == 1 && MouseBookData.Instance.GetLastMouseID() == 1)
            {
                if(UIManager.Instance.isUIon==false)
                {
                    TutorialFinger.transform.localPosition = new Vector2(22, -1557);
                }
                else
                {
                    TutorialFinger.transform.localPosition = new Vector2(22, -1152);
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
            MousesSelect();

            if (TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                TutorialLore.transform.GetChild(1).gameObject.GetComponent<Text>().text = "쥐가 두 마리 생겼쥐! \n 쥐 한 마리를 다른 한 마리로 드래그 해서 \n 쥐를 합쳐보쥐!";
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled = false;
            }
            if(TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().enabled == false)
            {
                TutorialFinger.transform.GetChild(0).gameObject.transform.localScale = new Vector3(1, 1, 1);
                TutorialFinger.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = TutorialFingerPointSprite;
            
            }

            if (UIManager.Instance.pposition.childCount == 1 && MouseBookData.Instance.GetLastMouseID() == 2)
            {
                if (UIManager.Instance.isUIon == false)
                {
                    SaveMouse.Instance.gameData.TutorialStage = 6;
                    TutorialFinger.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("TutorialFinger_Good");
                    TutorialBlocks[1].SetActive(false);
                    TutorialBlocks[2].SetActive(false);
                }
                else
                {
                    TutorialFinger.transform.localPosition = new Vector2(22, -1152);
                }
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
            Debug.Log(mouse1  + " " + mouse2);
            TutorialFinger.transform.localPosition = Vector2.Lerp(new Vector2(mouse1.transform.position.x, mouse1.transform.position.y), new Vector2(mouse2.transform.position.x, mouse2.transform.position.y), 10 * Time.deltaTime);
        }
    }
}
