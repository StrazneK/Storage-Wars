using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Participant : MonoBehaviour
{
    public float targetPrice = 0;
    float currentOffer = 0;
    bool startOffer = false;
    float leftTime = 0;
    [SerializeField] TextMeshProUGUI moneyTxt;
    Offer offer;

    void Start()
    {
        offer = GetComponent<Offer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startOffer) //teklif verme i�lemi ba�lad�ysa
        {
            Debug.Log("Teklif verme ba�lad�");
            leftTime -= Time.deltaTime;
            if (leftTime < 0)
            {
                Debug.Log("Zaman do�ru i�liyor");
                if (targetPrice > OfferControl.bestOffer)
                {
                    Debug.Log("Hedef para bestparadan b�y�k");
                    offer.SetOffer();
                    moneyTxt.text = "$" + OfferControl.bestOffer.ToString();
                }
                else
                {
                    startOffer = false;
                }
                leftTime = Time.deltaTime + Random.Range(.2f, 3); //tekrar ka� saniye sonra paray� art�raca��n� random olarak se�
            }
        }

    }
    public void SetTargetPrice(float price) 
    {
        Debug.Log("Teklif ayarlama ekran� a��ld�");
        Debug.Log("Teklif= " + price);
        targetPrice = price; //teklif edece�i miktar� ayarla
        startOffer = true; //teklif vermesini ba�lat
        moneyTxt.text = "$0"; // ilk teklifleri 0 olarak ayarla
        leftTime = Time.deltaTime + Random.Range(.2f, 3); //ka� saniye sonra paray� art�raca��n� random olarak se�
    }
}
