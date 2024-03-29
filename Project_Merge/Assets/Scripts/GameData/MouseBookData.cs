﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MouseBookData : Singleton<MouseBookData>
{
    public List<MouseVo> mouseBookList = new List<MouseVo>();
    [SerializeField]
    private GameObject MouseBookPrefab = null;
    [SerializeField]
    private GameObject MouseTapParent = null;
    [SerializeField]
    public GameObject NewMouseEffect = null;
    [SerializeField]
    public GameObject MouseBookDescImage = null;
    [SerializeField]
    private Sprite LockSprite = null;

    [SerializeField]
    private int LastMouseID = 0;

    [SerializeField]
    private bool FirstBookOn = false;

    public void MouseBookDatatable()
    {


        MouseVo mouse01 = new MouseVo(1, "들쥐", $"이게 머쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[1]:#,###}원", MouseSpriteManager.Instance.TileSprites[0].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse02 = new MouseVo(2, "햄스터", $"좀...귀엽쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[2]:#,###}원", MouseSpriteManager.Instance.TileSprites[1].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse03 = new MouseVo(3, "다람쥐", $"다람쥐도 쥐 맞쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[3]:#,###}원", MouseSpriteManager.Instance.TileSprites[2].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse04 = new MouseVo(4, "박쥐", $"박쥐는 포유류 맞쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[4]:#,###}원", MouseSpriteManager.Instance.TileSprites[3].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse05 = new MouseVo(5, "더럽쥐", $"어디서 냄새가...우욱 \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[5]:#,###}원", MouseSpriteManager.Instance.TileSprites[4].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse06 = new MouseVo(6, "쥐포", $"구워먹으면 맛있을지도? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[6]:#,###}원", MouseSpriteManager.Instance.TileSprites[5].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse07 = new MouseVo(7, "두더쥐", $"여기가 어디쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[7]:#,###}원", MouseSpriteManager.Instance.TileSprites[6].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse08 = new MouseVo(8, "마우스", $"컴퓨터는 어디있쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[8]:#,###}원", MouseSpriteManager.Instance.TileSprites[7].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse09 = new MouseVo(9, "간쥐", $"저 쥐... 멋.있.다! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[9]:#,###}원", MouseSpriteManager.Instance.TileSprites[8].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse10 = new MouseVo(10, "쥐갈공명", $"당신의 무기는 제껍니다. \n -쥐갈- \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[10]:#,###}원", MouseSpriteManager.Instance.TileSprites[9].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse11 = new MouseVo(11, "엑스라쥐", $"정말 크-쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[11]:#,###}원", MouseSpriteManager.Instance.TileSprites[10].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse12 = new MouseVo(12, "콩쥐&팥쥐", $"콩쥐 심은데 콩쥐난다? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[12]:#,###}원", MouseSpriteManager.Instance.TileSprites[11].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse13 = new MouseVo(13, "스티븐 쥐압스", $"치즈가 제시하는 혁신적인 세상. \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[13]:#,###}원", MouseSpriteManager.Instance.TileSprites[12].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse14 = new MouseVo(14, "패션 잡쥐", $"쥐들의 패션을 설명하쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[14]:#,###}원", MouseSpriteManager.Instance.TileSprites[13].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse15 = new MouseVo(15, "쥐폐", $"펄-럭 \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[15]:#,###}원", MouseSpriteManager.Instance.TileSprites[14].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse16 = new MouseVo(16, "주쥐스님", $"깨달음을 얻고싶쥐... \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[16]:#,###}원", MouseSpriteManager.Instance.TileSprites[15].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse17 = new MouseVo(17, "번개쥐", $"ㅍ...번개쥐 백볼트! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[17]:#,###}원", MouseSpriteManager.Instance.TileSprites[16].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse18 = new MouseVo(18, "다리에 쥐", $"윽! 다리에 쥐가! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[18]:#,###}원", MouseSpriteManager.Instance.TileSprites[17].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse19 = new MouseVo(19, "스폰쥐", $"오늘의 실험! 물을 흡수해보쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[19]:#,###}원", MouseSpriteManager.Instance.TileSprites[18].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse20 = new MouseVo(20, "가쥐", $"가쥐는 어디로 가쥐? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[20]:#,###}원", MouseSpriteManager.Instance.TileSprites[19].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse21 = new MouseVo(21, "강아쥐", $"왈! ㅇ...찍? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[21]:#,###}원", MouseSpriteManager.Instance.TileSprites[20].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse22 = new MouseVo(22, "콩깍쥐", $"내눈...! 에 콩깍쥐. \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[22]:#,###}원", MouseSpriteManager.Instance.TileSprites[21].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse23 = new MouseVo(23, "오렌쥐", $"이 게임을 한 쥐 얼마나 오렌쥐?\n잠깐! 먹지말쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[23]:#,###}원", MouseSpriteManager.Instance.TileSprites[22].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse24 = new MouseVo(24, "건전쥐", $"지치지 않쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[24]:#,###}원", MouseSpriteManager.Instance.TileSprites[23].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse25 = new MouseVo(25, "수도꼭쥐", $"콰아아ㅏㅏ아ㅏ \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[25]:#,###}원", MouseSpriteManager.Instance.TileSprites[24].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse26 = new MouseVo(26, "딱쥐", $"잠..잠깐 던지지 말쥐!! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[26]:#,###}원", MouseSpriteManager.Instance.TileSprites[25].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse27 = new MouseVo(27, "보석반쥐", $"사탕 같기도? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[27]:#,###}원", MouseSpriteManager.Instance.TileSprites[26].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse28 = new MouseVo(28, "미세먼쥐", $"내가 등장하면 마스크를 착용 하쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[28]:#,###}원", MouseSpriteManager.Instance.TileSprites[27].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse29 = new MouseVo(29, "휴쥐", $"이삿날 선물 뚝딱 \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[29]:#,###}원", MouseSpriteManager.Instance.TileSprites[28].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse30 = new MouseVo(30, "널빤쥐", $"밟지 말쥐! 찍! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[30]:#,###}원", MouseSpriteManager.Instance.TileSprites[29].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);

        MouseVo mouse31 = new MouseVo(31, "구쮜", $"플렉스- 하쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[31]:#,###}원", MouseSpriteManager.Instance.TileSprites[30].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse32 = new MouseVo(32, "쥐렁이", $"꿈-틀(밟힌듯 하다) \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[32]:#,###}원", MouseSpriteManager.Instance.TileSprites[31].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse33 = new MouseVo(33, "멧돼쥐", $"꾸이익? 찌찍? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[33]:#,###}원", MouseSpriteManager.Instance.TileSprites[32].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse34 = new MouseVo(34, "누룽쥐", $"뜨-끈하고 든-든한 누룽쥐탕 먹고싶쥐 \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[34]:#,###}원", MouseSpriteManager.Instance.TileSprites[33].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse35 = new MouseVo(35, "마이클 쥐액슨", $"나의 쥐-워크를 보쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[35]:#,###}원", MouseSpriteManager.Instance.TileSprites[34].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse36 = new MouseVo(36, "설거쥐", $"맑고 깨끗하고 자신있쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[36]:#,###}원", MouseSpriteManager.Instance.TileSprites[35].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse37 = new MouseVo(37, "아버쥐", $"생각만하면 눙물이 나쥐... \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[37]:#,###}원", MouseSpriteManager.Instance.TileSprites[36].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse38 = new MouseVo(38, "단무쥐", $"단무쥐의 뜻은 단순 무식 쥐! \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[38]:#,###}원", MouseSpriteManager.Instance.TileSprites[37].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse39 = new MouseVo(39, "황금쥐", $"오우 빛날줄 좀 아는 쥐인가? \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[39]:#,###}원", MouseSpriteManager.Instance.TileSprites[38].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        MouseVo mouse40 = new MouseVo(40, "십이간쥐", $"이 치즈가 식기 전에 고양이의 목에 방울을 달겠소 \n\n = 돈을 한번에 벌어오는 양 =\n{GameStat.Instance.MoneyDataTable[40]:#,###}원", MouseSpriteManager.Instance.TileSprites[39].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);

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
        SetLastMouseID(false);
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
            booktap.transform.GetChild(1).GetComponent<Text>().text = String.Format("{0}. {1}",i+1, mouseBookList[i].name);
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
            booktap.transform.GetChild(1).GetComponent<Text>().text = String.Format("{0}. {1}", i + 1, mouseBookList[i].name);
            booktap.GetComponent<MouseBookTap>().tapId = i + 1;
            booktap.GetComponent<MouseBookTap>().isLock = false;
        }
    }

    public void SetLastMouseID(bool isMerging) // 현재 최고 쥐 단계를 표시하게 하는 함수 -> LastMouseID에 저장/ 현재는 쥐들을 합칠때만 호출
    {
        GameObject[] miceCountDetect = GameObject.FindGameObjectsWithTag("Mouse");
        for (int i = 0; i < miceCountDetect.Length; i++)
        {
            if(miceCountDetect[i] == null)
                continue;
            if (miceCountDetect[i].GetComponent<MouseElement>().mouseID > LastMouseID)
            {
                LastMouseID = miceCountDetect[i].GetComponent<MouseElement>().mouseID;
                SaveMouse.Instance.SaveGameData();
                if(isMerging)
                    FirstBookOn = true;
            }
        }
    }

    public int GetLastMouseID() // private용
    {
        return LastMouseID;
    }

    private void Update()
    {
        if (FirstBookOn)
        {
            DescDisplayFirst();
            FirstBookOn = false;
        }
    }


    private void DescDisplayFirst()  // 새로 본 쥐를 봤을 때 뜨는 설명
    {
        UIManager.Instance.isUIon = true;
        UIManager.Instance.MouseBookDesc.SetActive(true);
        NewMouseEffect.SetActive(true);
        MouseBookDescImage.GetComponent<Image>().color = new Color(1, 0.9865527f, 0.9103774f, 0.8313726f);

        GameObject sprite = UIManager.Instance.MouseBookDescChild.transform.GetChild(0).gameObject;
        GameObject name = UIManager.Instance.MouseBookDescChild.transform.GetChild(1).gameObject;
        GameObject desc = UIManager.Instance.MouseBookDescChild.transform.GetChild(2).gameObject;

        sprite.GetComponent<Image>().sprite = mouseBookList[LastMouseID - 1].sprite;
        name.GetComponent<Text>().text = mouseBookList[LastMouseID - 1].name;
        desc.GetComponent<Text>().text = mouseBookList[LastMouseID - 1].desc;
    }
}
