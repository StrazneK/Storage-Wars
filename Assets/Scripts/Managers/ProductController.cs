using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductController : MonoBehaviour
{
    [SerializeField] Transform dirtPool;
    [SerializeField] ParticleSystem cleaningPart;
    public void Clean()
    {
        if (PlayerPrefs.GetInt("IsDirty", 0) == 0)
        {
            for (int i = 0; i < dirtPool.childCount; i++)
            {
                dirtPool.GetChild(i).gameObject.SetActive(false);
            }
            cleaningPart.Play();
        }
    }
}
