using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [Header("Rotate XYZ")]
    [SerializeField]
    private float RotateX = 0f;
    [SerializeField]
    private float RotateY = 0f;
    [SerializeField]
    private float RotateZ = 0f;
    void Update()
    {
        transform.Rotate(new Vector3(RotateX * Time.deltaTime, RotateY * Time.deltaTime, RotateZ * Time.deltaTime));
    }
}
