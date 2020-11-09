using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseElement : Singleton<MouseElement>
{
    public int mouseID = 0;


    public bool MoveWithComputerMouse = false;

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
        if (UIManager.Instance.isUIon)
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        else
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (MoveWithComputerMouse && spriteRenderer.enabled)
        {
            float targetPositionX = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2f, 2f);
            float targetPositionY = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -2.2f, 1.8f);
            transform.position = new Vector3(targetPositionX, targetPositionY, 0);
        }
    }

    void OnMouseDown()
    {
        MoveWithComputerMouse = true;
    }
    void OnMouseUp()
    {
        if (GetComponent<Rigidbody2D>().simulated == true)
        {
            MoveWithComputerMouse = false;
            OntoOtherOne();
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
                    if (triggered.GetComponent<MouseElement>().mouseID == gameObject.GetComponent<MouseElement>().mouseID)
                    {
                        triggered.transform.parent = UIManager.Instance.pposition.parent;
                        transform.parent = UIManager.Instance.pposition.parent;
                        Merge();
                        break;
                    }
                }
            }
        }
    }

    void Merge()
    {
        if (mouseID != 40)
            Destroy(triggered);

        UpdateMouseElementSprite();
    }

    void Hide()
    {

    }

    void UpdateMouseElementSprite()
    {
        for (int i = 0; i < 40; i++)
        {
            if (i == 39)
                break;
            if(mouseID == MSM.TileSprites[i].GetComponent<MouseElement>().mouseID)
            {
                GameObject mergedmouse = Instantiate(MSM.TileSprites[i + 1], transform.localPosition + new Vector3(0,0,0.1f), transform.localRotation);
                mergedmouse.transform.SetParent(uiManager.pposition.transform);
                mergedmouse.GetComponent<MouseElement>().Invoke("MergeOrCreate", 0.05f);
            }
        }
        if (mouseID != 40)
            Destroy(gameObject);

        MouseBookData.Instance.SetLastMouseID(true);
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
    }
}
