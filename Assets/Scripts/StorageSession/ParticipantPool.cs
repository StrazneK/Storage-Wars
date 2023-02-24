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
        productPool = ProductPool.instance; //ürün havuzu scriptini al
        participants.Add(GameObject.Find("You").transform); //kendimizi 0 idli yapýyoruz.
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name != "You") //biz hariç diðer herkesi sýrayla ekliyoruz
            {
                participants.Add(transform.GetChild(i)); //katýlýmcýlarý listeye ekle
            }
            firstPositions.Add(transform.GetChild(i).position); //UI'larýn ilk pozisyonlarýný kaydediyoruz.
        }
        for (int i = 0; i < participants.Count; i++)
        {
            float targetPrice = Random.Range(productPool.sumFirstPrice - (productPool.sumFirstPrice * 20 / 100), productPool.sumSecondPrice + (productPool.sumSecondPrice * 20 / 100)); //katýlýmcýnýn vereceði ücreti hesapla (minimum toplamýn %20 eksiði ile maksimumun %20 fazlasý arasýnda)
            if (i != 0) ///0'da biz olduðumuz için hedef teklif ayarlamýyoruz
                participants[i].GetComponent<Participant>().SetTargetPrice(targetPrice); //katýlýmcýlarýn tekliflerini ayarla
            participants[i].GetComponent<Offer>().SetIds(i); //idlerini bilsinler
        }
    }
    private void Update()
    {
        if (sortOffers)
        {
            int partOfferId = -1;
            for (int i = 0; i < participants.Count; i++) //tüm katýlýmcýlara bak
            {
                Offer partOffer = participants[i].GetComponent<Offer>();
                if (partOffer.posId == bestPosId) // katýlýmcýnýn idsi bestPosId'ye eþit mi
                {
                    partOfferId = i;
                    break;
                }
            }
            for (int i = bestPosId - 1; i >= 0; i--)
            {
                for (int j = 0; j < participants.Count; j++) //tüm katýlýmcýlara bak
                {
                    Offer partOffer = participants[j].GetComponent<Offer>();
                    if (partOffer.posId == i) // katýlýmcýnýn idsi i'ye eþit mi
                    {
                        partOffer.posId++; //posId'sini 1 arttýr
                        participants[j].position = firstPositions[partOffer.posId]; //yeni pozisyonuna gönder                        }
                    }
                }
            }
            participants[partOfferId].GetComponent<Offer>().posId = 0;
            participants[partOfferId].position = firstPositions[0]; //yeni pozisyonuna gönder    
            sortOffers = false;
        }
    }
    public void SortOffers(int partId)
    {
        sortOffers = true;
        bestPosId = participants[partId].GetComponent<Offer>().posId;
    }
}
