using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantPool : MonoBehaviour
{
    ProductPool productPool;
    List<Transform> participants = new List<Transform>();
    List<Vector2> firstPositions = new List<Vector2>();
    bool sortOffers;
    int bestPosId = 0;
    public bool IsPlayerWin = false;

    public static ParticipantPool instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(StartSettings());
    }
    IEnumerator StartSettings()
    {
        yield return new WaitForSeconds(.5f);
        productPool = ProductPool.instance; //�r�n havuzu scriptini al
        participants.Add(GameObject.Find("You").transform); //kendimizi 0 idli yap�yoruz.
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name != "You") //biz hari� di�er herkesi s�rayla ekliyoruz
            {
                participants.Add(transform.GetChild(i)); //kat�l�mc�lar� listeye ekle
            }
            firstPositions.Add(transform.GetChild(i).position); //UI'lar�n ilk pozisyonlar�n� kaydediyoruz.
        }
        for (int i = 0; i < participants.Count; i++)
        {
            float targetPrice = Random.Range(productPool.sumFirstPrice - (productPool.sumFirstPrice * 20 / 100), productPool.sumSecondPrice + (productPool.sumSecondPrice * 20 / 100)); //kat�l�mc�n�n verece�i �creti hesapla (minimum toplam�n %20 eksi�i ile maksimumun %20 fazlas� aras�nda)
            if (i != 0) ///0'da biz oldu�umuz i�in hedef teklif ayarlam�yoruz
                participants[i].GetComponent<Participant>().SetTargetPrice(targetPrice); //kat�l�mc�lar�n tekliflerini ayarla
            participants[i].GetComponent<Offer>().SetIds(i); //idlerini bilsinler
        }
    }
    private void Update()
    {
        if (sortOffers)
        {
            int partOfferId = -1;
            for (int i = 0; i < participants.Count; i++) //t�m kat�l�mc�lara bak
            {
                Offer partOffer = participants[i].GetComponent<Offer>();
                if (partOffer.posId == bestPosId) // kat�l�mc�n�n idsi bestPosId'ye e�it mi
                {
                    partOfferId = i;
                    break;
                }
            }
            for (int i = bestPosId - 1; i >= 0; i--)
            {
                for (int j = 0; j < participants.Count; j++) //t�m kat�l�mc�lara bak
                {
                    Offer partOffer = participants[j].GetComponent<Offer>();
                    if (partOffer.posId == i) // kat�l�mc�n�n idsi i'ye e�it mi
                    {
                        partOffer.posId++; //posId'sini 1 artt�r
                        participants[j].position = firstPositions[partOffer.posId]; //yeni pozisyonuna g�nder                        }
                    }
                }
            }
            participants[partOfferId].GetComponent<Offer>().posId = 0;
            participants[partOfferId].position = firstPositions[0]; //yeni pozisyonuna g�nder    
            sortOffers = false;
        }
    }
    public void SortOffers(int partId)
    {
        sortOffers = true;
        bestPosId = participants[partId].GetComponent<Offer>().posId;
    }
}
