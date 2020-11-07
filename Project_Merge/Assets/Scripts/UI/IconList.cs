using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconList : MonoBehaviour
{
    private bool isEnabled = false;
    private float bottom = 1;

    public void ListButtonClick()
    {
        if (isEnabled)
        {
            isEnabled = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            isEnabled = true;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
            }
        }
    }

    void Update()
    {
        if(isEnabled)
        {
            bottom = Mathf.Lerp(bottom, -800, 10f * Time.deltaTime);
        }
        else
        {
            bottom = Mathf.Lerp(bottom, 1, 10f * Time.deltaTime);
        }

        if (bottom > -1 && !isEnabled)
            bottom = 1;
        GetComponent<RectTransform>().offsetMin = new Vector2(0, bottom);
    }
}
