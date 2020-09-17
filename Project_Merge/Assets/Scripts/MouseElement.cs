using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseElement : MonoBehaviour
{
    [SerializeField]
    private int mouseID = 0;

    bool MoveWithComputerMouse = false;
    bool CollidedWithOther = false;

    MouseSpriteManager MSM;
    GameObject triggered;

    void Awake()
    {
        MSM = FindObjectOfType<MouseSpriteManager>();
    }

    void Update()
    {
        if (MoveWithComputerMouse && GetComponent<SpriteRenderer>().enabled)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }
    void OnMouseDown()
    {
        MoveWithComputerMouse = true;
    }
    void OnMouseUp()
    {
        MoveWithComputerMouse = false;
        if (CollidedWithOther)
        {
            OntoOtherOne();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<MouseElement>())
        {
            triggered = col.gameObject;
            CollidedWithOther = true;
        }
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
        if (triggered.GetComponent<MouseElement>().mouseID == gameObject.GetComponent<MouseElement>().mouseID)
        {
            Merge();
        }
    }

    void Merge()
    {
        triggered.GetComponent<MouseElement>().UpdateMouseElementSprite();
        Hide();
    }

    void Hide()
    {
        if(GetComponent<MouseElement>().mouseID != 40)
        Destroy(gameObject);
    }

    void UpdateMouseElementSprite()
    {
        for (int i = 0; i < 40; i++)
        {
            if (i == 39)
                break;
            if(gameObject.GetComponent<MouseElement>().mouseID == MSM.TileSprites[i].GetComponent<MouseElement>().mouseID)
                Instantiate(MSM.TileSprites[i+1], triggered.transform.localPosition, triggered.transform.localRotation);
        }
        if (gameObject.GetComponent<MouseElement>().mouseID != 40)
            Destroy(gameObject);
    }
}
