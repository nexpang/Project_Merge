using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCheesePop : EffectDestroy
{
    private Rigidbody2D rigid = null;
    private void Start()
    {
        float targetScale = Random.Range(0.2f, 0.3f);

        float targetPositionX = Random.Range(-0.7f, 0.7f);
        float targetPositionY = Random.Range(-1f, 1f);

        Vector2 randomPositionEffect = new Vector2(transform.localPosition.x - 5, transform.localPosition.y);

        transform.localScale = new Vector3(targetScale,targetScale, 1);
        transform.localPosition = randomPositionEffect;

        rigid = gameObject.GetComponent<Rigidbody2D>();

        float randomX = 0;

        if (targetPositionX > 0)
        {
            randomX = Random.Range(0, 3f);

        }
        else if (targetPositionX < 0)
        {
            randomX = Random.Range(-3f, 0);

        }
        float randomy = Random.Range(5f, 8f);

        Vector2 randomForce = new Vector2(randomX, randomy);
        rigid.AddForce(randomForce, ForceMode2D.Impulse);

        StartCoroutine(DestroyThis());
    }
    private void Update()
    {
        float clampX = Mathf.Clamp(gameObject.transform.position.x, -7f, -3f);
        float clampY = Mathf.Clamp(gameObject.transform.position.y, -5f, 5f);

        gameObject.transform.position = new Vector2(clampX, clampY);
    }
}
