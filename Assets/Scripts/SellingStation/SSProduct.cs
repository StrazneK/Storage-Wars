using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSProduct : MonoBehaviour
{
    Transform selectedProd;
    void Start()
    {
        selectedProd = ProductManager.instance.GetProduct(0, true);
        selectedProd.parent = transform;
        selectedProd.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
