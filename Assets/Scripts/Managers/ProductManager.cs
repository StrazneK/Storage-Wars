using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public static ProductManager instance;
    
    List<Transform> products = new List<Transform>();

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < transform.childCount; i++)
        {
            products.Add(transform.GetChild(i));
        }
    }
    public Transform GetProduct(int productId,bool isClean)
    {
        if (isClean) products[productId].GetComponent<ProductController>().Clean();
        return products[productId];
    }
}
