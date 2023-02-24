using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerOfferControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyTxt;
    Offer offer;

    void Start()
    {
        offer = GetComponent<Offer>();
        moneyTxt.text = "$0";
    }
    public void IncreaseOffer()
    {
        offer.SetOffer();
        moneyTxt.text = "$" + OfferControl.bestOffer.ToString();
    }
}
