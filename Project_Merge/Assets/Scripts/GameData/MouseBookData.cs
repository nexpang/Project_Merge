using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MouseBookData : Singleton<MouseBookData>
{
    List<MouseVo> mouseBookList = new List<MouseVo>();
    [SerializeField]
    private GameObject MouseBookPrefab = null;
    [SerializeField]
    private GameObject MouseTapParent = null;
    [SerializeField]
    private Sprite LockSprite = null;

    [SerializeField]
    private int LastMouseID = 0;

    public void MouseBookDatatable()
    {

        MouseVo mouse01 = new MouseVo(1, "들쥐", "이게 머쥐?", MouseSpriteManager.Instance.TileSprites[0].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse02 = new MouseVo(2, "햄스터", "", MouseSpriteManager.Instance.TileSprites[1].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse03 = new MouseVo(3, "다람쥐", "", MouseSpriteManager.Instance.TileSprites[2].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse04 = new MouseVo(4, "박쥐", "", MouseSpriteManager.Instance.TileSprites[3].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse05 = new MouseVo(5, "더럽쥐", "", MouseSpriteManager.Instance.TileSprites[4].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse06 = new MouseVo(6, "쥐포", "", MouseSpriteManager.Instance.TileSprites[5].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse07 = new MouseVo(7, "두더쥐", "", MouseSpriteManager.Instance.TileSprites[6].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse08 = new MouseVo(8, "마우스", "", MouseSpriteManager.Instance.TileSprites[7].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse09 = new MouseVo(9, "간쥐", "", MouseSpriteManager.Instance.TileSprites[8].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse10 = new MouseVo(10, "쥐갈공명", "", MouseSpriteManager.Instance.TileSprites[9].GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse11 = new MouseVo(11, "엑스라쥐", "", MouseSpriteManager.Instance.TileSprites[10].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse12 = new MouseVo(12, "콩쥐&팥쥐", "", MouseSpriteManager.Instance.TileSprites[11].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse13 = new MouseVo(13, "스티븐 쥐압스", "", MouseSpriteManager.Instance.TileSprites[12].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse14 = new MouseVo(14, "패션 잡쥐", "", MouseSpriteManager.Instance.TileSprites[13].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse15 = new MouseVo(15, "쥐폐", "", MouseSpriteManager.Instance.TileSprites[14].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse16 = new MouseVo(16, "주쥐스님", "", MouseSpriteManager.Instance.TileSprites[15].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse17 = new MouseVo(17, "번개쥐", "", MouseSpriteManager.Instance.TileSprites[16].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse18 = new MouseVo(18, "다리에 쥐", "", MouseSpriteManager.Instance.TileSprites[17].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse19 = new MouseVo(19, "스폰쥐", "", MouseSpriteManager.Instance.TileSprites[18].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse20 = new MouseVo(20, "가쥐", "", MouseSpriteManager.Instance.TileSprites[19].GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse21 = new MouseVo(21, "강아쥐", "", MouseSpriteManager.Instance.TileSprites[20].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse22 = new MouseVo(22, "콩깍쥐", "", MouseSpriteManager.Instance.TileSprites[21].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse23 = new MouseVo(23, "오렌쥐", "", MouseSpriteManager.Instance.TileSprites[22].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse24 = new MouseVo(24, "건전쥐", "", MouseSpriteManager.Instance.TileSprites[23].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse25 = new MouseVo(25, "수도꼭쥐", "", MouseSpriteManager.Instance.TileSprites[24].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse26 = new MouseVo(26, "딱쥐", "", MouseSpriteManager.Instance.TileSprites[25].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse27 = new MouseVo(27, "보석반쥐", "", MouseSpriteManager.Instance.TileSprites[26].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse28 = new MouseVo(28, "미세먼쥐", "", MouseSpriteManager.Instance.TileSprites[27].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse29 = new MouseVo(29, "게딱쥐", "", MouseSpriteManager.Instance.TileSprites[28].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse30 = new MouseVo(30, "널빤쥐", "", MouseSpriteManager.Instance.TileSprites[29].GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse31 = new MouseVo(31, "구쮜", "", MouseSpriteManager.Instance.TileSprites[30].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse32 = new MouseVo(32, "쥐렁이", "", MouseSpriteManager.Instance.TileSprites[31].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse33 = new MouseVo(33, "멧돼쥐", "", MouseSpriteManager.Instance.TileSprites[32].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse34 = new MouseVo(34, "누룽쥐", "", MouseSpriteManager.Instance.TileSprites[33].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse35 = new MouseVo(35, "마이클 쥐액슨", "", MouseSpriteManager.Instance.TileSprites[34].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse36 = new MouseVo(36, "설거쥐", "", MouseSpriteManager.Instance.TileSprites[35].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse37 = new MouseVo(37, "아버쥐", "", MouseSpriteManager.Instance.TileSprites[36].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse38 = new MouseVo(38, "단무쥐", "", MouseSpriteManager.Instance.TileSprites[37].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse39 = new MouseVo(39, "황금쥐", "", MouseSpriteManager.Instance.TileSprites[38].GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse40 = new MouseVo(40, "십이간쥐", "", MouseSpriteManager.Instance.TileSprites[39].GetComponent<SpriteRenderer>().sprite);

        mouseBookList.Add(mouse01);
        mouseBookList.Add(mouse02);
        mouseBookList.Add(mouse03);
        mouseBookList.Add(mouse04);
        mouseBookList.Add(mouse05);
        mouseBookList.Add(mouse06);
        mouseBookList.Add(mouse07);
        mouseBookList.Add(mouse08);
        mouseBookList.Add(mouse09);
        mouseBookList.Add(mouse10);

        mouseBookList.Add(mouse11);
        mouseBookList.Add(mouse12);
        mouseBookList.Add(mouse13);
        mouseBookList.Add(mouse14);
        mouseBookList.Add(mouse15);
        mouseBookList.Add(mouse16);
        mouseBookList.Add(mouse17);
        mouseBookList.Add(mouse18);
        mouseBookList.Add(mouse19);
        mouseBookList.Add(mouse20);

        mouseBookList.Add(mouse21);
        mouseBookList.Add(mouse22);
        mouseBookList.Add(mouse23);
        mouseBookList.Add(mouse24);
        mouseBookList.Add(mouse25);
        mouseBookList.Add(mouse26);
        mouseBookList.Add(mouse27);
        mouseBookList.Add(mouse28);
        mouseBookList.Add(mouse29);
        mouseBookList.Add(mouse30);

        mouseBookList.Add(mouse31);
        mouseBookList.Add(mouse32);
        mouseBookList.Add(mouse33);
        mouseBookList.Add(mouse34);
        mouseBookList.Add(mouse35);
        mouseBookList.Add(mouse36);
        mouseBookList.Add(mouse37);
        mouseBookList.Add(mouse38);
        mouseBookList.Add(mouse39);
        mouseBookList.Add(mouse40);

    }


    private void Start()
    {
        int j = 0;
        MouseBookDatatable();
        SetLastMouseID();
        for (int i = 0; i < mouseBookList.Count; i++)
        {
            GameObject booktap = Instantiate(MouseBookPrefab, MouseTapParent.transform);
            booktap.transform.SetParent(MouseTapParent.transform);
            if (i % 3 == 0)
            {
                booktap.GetComponent<RectTransform>().anchoredPosition = new Vector2(-450, 3930 - j * 560);
            }
            else if (i % 3 == 1)
            {
                booktap.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 3930 - j * 560);
            }
            else if (i % 3 == 2)
            {
                booktap.GetComponent<RectTransform>().anchoredPosition = new Vector2(450, 3930 - j * 560);
                j++;
            }
            if(LastMouseID < i)
            {
                booktap.transform.GetChild(0).GetComponent<Image>().sprite = LockSprite;
                booktap.transform.GetChild(1).GetComponent<Text>().text = "잠김";
                booktap.GetComponent<MouseBookTap>().tapId = i + 1;
                booktap.GetComponent<MouseBookTap>().isLock = true;
                continue;
            }
            booktap.transform.GetChild(0).GetComponent<Image>().sprite = mouseBookList[i].sprite;
            booktap.transform.GetChild(1).GetComponent<Text>().text = mouseBookList[i].name;
            booktap.GetComponent<MouseBookTap>().tapId = i + 1;
        }
    }

    public void RefreshBook()
    {
        for (int i = 0; i < MouseTapParent.transform.childCount; i++)
        {
            GameObject booktap = MouseTapParent.transform.GetChild(i).gameObject;
            if (LastMouseID < i + 1)
            {
                booktap.transform.GetChild(0).GetComponent<Image>().sprite = LockSprite;
                booktap.transform.GetChild(1).GetComponent<Text>().text = "잠김";
                booktap.GetComponent<MouseBookTap>().tapId = i + 1;
                booktap.GetComponent<MouseBookTap>().isLock = true;
                continue;
            }
            booktap.transform.GetChild(0).GetComponent<Image>().sprite = mouseBookList[i].sprite;
            booktap.transform.GetChild(1).GetComponent<Text>().text = mouseBookList[i].name;
            booktap.GetComponent<MouseBookTap>().tapId = i + 1;
        }
    }

    public void SetLastMouseID() // 현재 최고 쥐 단계를 표시하게 하는 함수 -> LastMouseID에 저장/ 현재는 쥐들을 합칠때만 호출
    {
        for(int i = 0; i < UIManager.Instance.pposition.childCount; i++)
        {
            GameObject[] mice = GameObject.FindGameObjectsWithTag("Mouse");
            if (mice[i].GetComponent<MouseElement>().mouseID > LastMouseID)
            {
                LastMouseID = mice[i].GetComponent<MouseElement>().mouseID;
                SaveMouse.Instance.SaveGameData();
            }
        }
    }
}
