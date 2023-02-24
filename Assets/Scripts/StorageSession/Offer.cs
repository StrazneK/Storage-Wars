using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offer : MonoBehaviour
{
    public int partId = -1;
    public int posId = -1;
    public float currentOffer = 0;
    ParticipantPool participantPool;
    private void Start()
    {
        participantPool = ParticipantPool.instance;
    }
    public void SetOffer()
    {
        ParticipantPool.instance.IsPlayerWin = partId == 0;
        OfferControl.bestOffer = currentOffer = OfferControl.bestOffer + 200;
        participantPool.SortOffers(partId);
        transform.parent.GetComponent<OfferControl>().AddTime();
    }
    public void SetIds(int _partId)
    {
        posId = partId = _partId;
    }
}
