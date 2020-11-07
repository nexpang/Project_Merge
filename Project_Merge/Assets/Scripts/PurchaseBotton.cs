using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseBotton : MonoBehaviour
{
    public string targetProductId;
    public void HandClick()
    {
        IAPManager.Instance.Purchase(targetProductId);
    }
}
