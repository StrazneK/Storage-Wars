using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerControl : MonoBehaviour
{
    [SerializeField] Transform customersPool;
    [SerializeField] Transform customerArea;
    [SerializeField] Transform customerOffer;
    [SerializeField] Transform offerPanel;
    [SerializeField] TextMeshPro txtOfferMoney;
    [SerializeField] Transform badOffer;
    [SerializeField] Transform goodOffer;
    [SerializeField] float customerSpeed=15;

    List<Transform> customers = new List<Transform>();
    Transform selectedCust;
    bool custInArea = true;
    float offerMoney;
    void Start()
    {
        for (int i = 0; i < customersPool.childCount; i++)
        {
            customers.Add(customersPool.GetChild(i));
            customersPool.GetChild(i).gameObject.SetActive(false);
        }
        SetCustomer(RandomCustomerId());
        offerMoney = Random.Range(1000, 4501);
    }
    private void Update()
    {
        if (!custInArea)
        {
            selectedCust.position = Vector3.Lerp(selectedCust.position, customerArea.position, customerSpeed * Time.deltaTime);
            if (selectedCust.position.z < customerArea.position.z + .2f)
            {
                txtOfferMoney.text = "$" + offerMoney.ToString();
                if (offerMoney < 2200)
                {
                    badOffer.gameObject.SetActive(true);
                }
                else
                {
                    goodOffer.gameObject.SetActive(true);
                }
                OCOfferPanel(true);
                custInArea = true;
            }
        }
    }
    void OCOfferPanel(bool open)
    {
        customerArea.gameObject.SetActive(open);
        customerOffer.gameObject.SetActive(open);
        offerPanel.gameObject.SetActive(open);
    }
    public void SetCustomer(int customerId)
    {
        selectedCust = customers[customerId];
        customers[customerId].gameObject.SetActive(true);
        custInArea = false;
    }
    int RandomCustomerId()
    {
        return Random.Range(0, customers.Count);
    }
    public void SellProduct()
    {
        MoneyController.instance.AddMoney(offerMoney);
        CameraController.instance.PlayConfetti();
        StartCoroutine(NextGame());

    }
    IEnumerator NextGame()
    {
        yield return new WaitForSeconds(.9f);
        LevelController.instance.NextLevel();
    }
}
