using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPool : MonoBehaviour
{
    public float sumFirstPrice = 0;
    public float sumSecondPrice = 0;
    public static ProductPool instance;
    private void Awake()
    {
        instance = this;
    }
}
