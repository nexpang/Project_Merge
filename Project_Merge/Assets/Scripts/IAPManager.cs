using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour , IStoreListener
{
    public const string productFewCash = "FewCash";
    public const string productMiddleCash = "MiddleCash";
    public const string productExpensiveCash= "ExpensiveCash";
    public const string productVeryExpensiveCash= "VeryExpensiveCash";

    private const string _android_FewCashId = "mergecash_1";
    private const string _android_MiddleCashId = "mergecash_2";
    private const string _android_ExpensiveCashId = "mergecash_3";
    private const string _android_VeryExpensiveCashId = "mergecash_4";


    //싱글톤====================
    private static IAPManager m_instance;
    public static IAPManager Instance
    {
        get
        {
            if(m_instance != null) return m_instance;

            m_instance = FindObjectOfType<IAPManager>();

            if (m_instance == null) m_instance = new GameObject().AddComponent<IAPManager>();
            return m_instance;
        }
    }
    // =================================================

    public bool isInitialized
    {
        get
        {
            if(storeController != null && storeExtensionProvider != null)
            {
                return true;
            }
            return false;
        }
    }

    private IStoreController storeController; //구매 과정 제어하는 함수 제공
    private IExtensionProvider storeExtensionProvider;//여러 플렛폼을 위한 확장 처리 제공

    public bool IsInitialized => storeController != null && storeExtensionProvider != null;

    private void Awake()
    {
        if(m_instance != null && m_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        InitUnityIAP();
    }
    void InitUnityIAP()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(
            id: productFewCash, ProductType.Consumable, new IDs()
            {
                {_android_FewCashId,GooglePlay.Name}}
            );
        builder.AddProduct(
            id: productMiddleCash, ProductType.Consumable, new IDs()
            {
                {_android_MiddleCashId,GooglePlay.Name}}
            );
        builder.AddProduct(
            id: productExpensiveCash, ProductType.Consumable, new IDs()
            {
                {_android_ExpensiveCashId,GooglePlay.Name}}
            );
        builder.AddProduct(
            id: productVeryExpensiveCash, ProductType.Consumable, new IDs()
            {
                {_android_VeryExpensiveCashId,GooglePlay.Name}}
            );

        UnityPurchasing.Initialize(listener:this,builder);
    }
    public void OnInitialized(IStoreController controller,IExtensionProvider extension)
    {
        Debug.Log(message: "유니티 IAP초기화 성공");
        storeController = controller;
        storeExtensionProvider = extension;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError(message: $"유니티 IAP초기화 실패{error}");
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log(message: $"구매 성공 - ID : {args.purchasedProduct.definition.id}");

        if(args.purchasedProduct.definition.id == productFewCash)
        {
            //캐쉬 상승처리
            Debug.Log("작은돈");
            SaveMouse.Instance.gameData.JewelryMoney += 500;
        }
        else if (args.purchasedProduct.definition.id == productMiddleCash)
        {
            //캐쉬 상승처리
            Debug.Log("중간돈");
            SaveMouse.Instance.gameData.JewelryMoney += 3000;
        }
        else if (args.purchasedProduct.definition.id == productExpensiveCash)
        {
            //캐쉬 상승처리
            Debug.Log("큰돈");
            SaveMouse.Instance.gameData.JewelryMoney += 10000;
        }
        else if(args.purchasedProduct.definition.id == productVeryExpensiveCash)
        {
            Debug.Log("매우 큰돈");
            SaveMouse.Instance.gameData.JewelryMoney += 100000;
        }
        return PurchaseProcessingResult.Complete;
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning(message: $"구매실패 - {product.definition.id},{reason}");
    }
    public void Purchase(string productId)
    {
        if (!isInitialized) return;

        var product = storeController.products.WithID(productId);

        if(product != null && product.availableToPurchase)
        {
            Debug.Log(message: $"구매 시도 - {product.definition.id}");
            storeController.InitiatePurchase(product);
        }
        else
        {
            Debug.Log(message: $"구매 시도 불가 - {productId}");
        }
    }
    
}
