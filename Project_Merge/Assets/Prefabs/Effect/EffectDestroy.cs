using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    [SerializeField]
    private float DestroyTime = 0.5f;
    void Start()
    {
        StartCoroutine(DestroyThis());
    }

    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
}
