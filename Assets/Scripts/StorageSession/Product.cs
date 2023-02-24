using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Product : MonoBehaviour
{
    public float firstPrice;
    public float secondPrice;
    public float yPos = 2;
    public bool isBomb = false;
    Transform mainPriceUI;
    Transform priceUI;
    Camera cam;
    ProductPool productPool;
    private void Awake()
    {
      /*  if (!isBomb)
        {
            productPool = ProductPool.instance;
            productPool.sumFirstPrice += firstPrice;
            productPool.sumSecondPrice += secondPrice;
            Debug.Log("product");
        }*/
    }
    private void Start()
    {
        productPool = ProductPool.instance;
        productPool.sumFirstPrice += firstPrice;
        productPool.sumSecondPrice += secondPrice;
        Debug.Log(productPool.sumFirstPrice);
        Debug.Log("product");
        /* if (isBomb)
         {
             productPool = ProductPool.instance;
             productPool.sumFirstPrice += firstPrice;
             productPool.sumSecondPrice += secondPrice;
             Debug.Log("product");
         }*/

        cam = Camera.main;
        mainPriceUI = GameObject.Find("PriceUI").transform;
        priceUI = Instantiate(mainPriceUI, mainPriceUI.parent);
        priceUI.transform.position = cam.WorldToScreenPoint(transform.position + Vector3.up * yPos);
        priceUI.GetComponent<TextMeshProUGUI>().enabled = true;
        priceUI.GetComponent<TextMeshProUGUI>().text = "$"+firstPrice.ToString() + " - $" + secondPrice.ToString();
    }
}
