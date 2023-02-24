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
        if (startOffer) //teklif verme iþlemi baþladýysa
        {
            Debug.Log("Teklif verme baþladý");
            leftTime -= Time.deltaTime;
            if (leftTime < 0)
            {
                Debug.Log("Zaman doðru iþliyor");
                if (targetPrice > OfferControl.bestOffer)
                {
                    Debug.Log("Hedef para bestparadan büyük");
                    offer.SetOffer();
                    moneyTxt.text = "$" + OfferControl.bestOffer.ToString();
                }
                else
                {
                    startOffer = false;
                }
                leftTime = Time.deltaTime + Random.Range(.2f, 3); //tekrar kaç saniye sonra parayý artýracaðýný random olarak seç
            }
        }

    }
    public void SetTargetPrice(float price) 
    {
        Debug.Log("Teklif ayarlama ekraný açýldý");
        Debug.Log("Teklif= " + price);
        targetPrice = price; //teklif edeceði miktarý ayarla
        startOffer = true; //teklif vermesini baþlat
        moneyTxt.text = "$0"; // ilk teklifleri 0 olarak ayarla
        leftTime = Time.deltaTime + Random.Range(.2f, 3); //kaç saniye sonra parayý artýracaðýný random olarak seç
    }
}
