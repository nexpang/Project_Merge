using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseElement : MonoBehaviour
{
    public int mouseID = 0;


    bool MoveWithComputerMouse = false;
    bool CollidedWithOther = false;

    MouseSpriteManager MSM;
    GameObject triggered = null;
    UIManager uiManager;
    SpriteRenderer spriteRenderer;
    private MouseElement[] mice;
    private float distance = 0f;
    [SerializeField]
    private float collideDistance = 0f;

    private void OnEnable()
    {
        StartCoroutine(GetMoney());
    }

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        MSM = FindObjectOfType<MouseSpriteManager>();
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
    }

    void Update()
    {
        if (MoveWithComputerMouse && spriteRenderer.enabled)
        {
            float targetPositionX = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2f, 2f);
            float targetPositionY = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.5f, 3.5f);
            transform.position = new Vector3(targetPositionX, targetPositionY, 0);
        }
    }
    void OnMouseDown()
    {
        MoveWithComputerMouse = true;
    }
    void OnMouseUp()
    {
        MoveWithComputerMouse = false;
        OntoOtherOne();
        SaveMouse.Instance.MiceXYSave();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<MouseElement>())
        {
            CollidedWithOther = false;
        }
    }

    void OntoOtherOne()
    {
        mice = FindObjectsOfType<MouseElement>();
        foreach (MouseElement mouse in mice)
        {
            if (gameObject != mouse.gameObject)
            {
                distance = Vector2.Distance(transform.position, mouse.transform.position);
                if (distance <= collideDistance)
                {
                    triggered = mouse.gameObject;
                    CollidedWithOther = true;
                    if (triggered.GetComponent<MouseElement>().mouseID == gameObject.GetComponent<MouseElement>().mouseID)
                    {
                        Merge();
                        break;
                    }
                }
            }
        }
    }

    void Merge()
    {
        GetComponent<MouseElement>().UpdateMouseElementSprite();
        Hide();
    }

    void Hide()
    {
        if(GetComponent<MouseElement>().mouseID != 40)
        Destroy(triggered.gameObject);
    }

    void UpdateMouseElementSprite()
    {
        for (int i = 0; i < 40; i++)
        {
            if (i == 39)
                break;
            if(gameObject.GetComponent<MouseElement>().mouseID == MSM.TileSprites[i].GetComponent<MouseElement>().mouseID)
            {
                GameObject mergedmouse = Instantiate(MSM.TileSprites[i + 1], transform.localPosition + new Vector3(0,0,0.1f), transform.localRotation);
                mergedmouse.transform.SetParent(uiManager.pposition.transform);
                mergedmouse.GetComponent<MouseElement>().Invoke("MergeOrCreate", 0.05f);
            }
        }
        if (gameObject.GetComponent<MouseElement>().mouseID != 40)
            Destroy(gameObject);
    }


    private IEnumerator GetMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameStat.Instance.Upgrade_MoneyElapsedTime);
            UIManager.Instance.AddMoney(GameStat.Instance.MoneyDataTable[mouseID]);
            GameObject coinAnimation = Instantiate(GameObjectBox.Instance.CoinAnimation, new Vector3(transform.localPosition.x, transform.localPosition.y + 2, -0.15f), transform.rotation);
            coinAnimation.transform.SetParent(gameObject.transform);
        }
    }

    public void MergeOrCreate()
    {
        Instantiate(GameObjectBox.Instance.CheeseAnimation, new Vector3(transform.localPosition.x, transform.localPosition.y, -0.2f), transform.rotation);
        GameObject.Find("AudioResources").GetComponent<AudioManager>().FMouseSqueaky();
        SaveMouse.Instance.SaveGameData();
    }
}
