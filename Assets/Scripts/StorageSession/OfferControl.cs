using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferControl : MonoBehaviour
{
    public static float bestOffer = 0;
    List<Offer> offers = new List<Offer>();
    List<Transform> offerOrder = new List<Transform>();
    float offerCountdown = 5;
    bool offerActive = true;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            offers.Add(transform.GetChild(i).GetComponent<Offer>());
            offerOrder.Add(transform.GetChild(i));
        }
    }
    private void Update()
    {
        if (offerActive)
        {
            offerCountdown -= Time.deltaTime;
            if (offerCountdown < 0)
            {
                Debug.Log("Açýk artýrma sonlandý");
                offerActive = false;
                if (ParticipantPool.instance.IsPlayerWin)
                {
                    CameraController.instance.PlayConfetti();
                    StartCoroutine(MenuController.instance.WinPanelWSec(.8f));
                    MoneyController.instance.AddMoney(-bestOffer);
                }
                else
                {
                    MenuController.instance.LosePanel();
                }
            }
        }
    }
    public void AddTime()
    {
        offerCountdown = Time.deltaTime + 5f;
    }
}
