using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionManager : Singleton<FunctionManager>
{
    //필요할꺼 같은 함수 직접 만들어서 쓸꺼임
    public void TimeDestroy(GameObject go, float time) // 대신 지워드립니다
    {
        StartCoroutine(Destroy(go, time));
    }

    private IEnumerator Destroy(GameObject go, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(go);
    }



}
