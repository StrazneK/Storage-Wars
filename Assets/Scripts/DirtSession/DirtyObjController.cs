using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyObjController : MonoBehaviour
{
    public static DirtyObjController instance;

    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] ParticleSystem cleanParticle;
    Material material;
    bool goSmoothness = false;
    float leftTime = .1f;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        material = meshRenderer.material;
        material.SetFloat("_Smoothness", 0);
    }
    private void Update()
    {
        leftTime -= Time.deltaTime;
        if (goSmoothness && leftTime < 0)
        {
            material.SetFloat("_Smoothness", material.GetFloat("_Smoothness") + .01f);
            if (material.GetFloat("_Smoothness") >= .91f)
            {
                goSmoothness = false;
            }
            leftTime = Time.deltaTime + .01f;
        }
    }
    public void SuccessClean()
    {
        goSmoothness = true;
        cleanParticle.Play();
        PlayerPrefs.SetInt("IsDirty", 0); //diðer ekranda temiz baþlamasý için
        CameraController.instance.PlayConfetti();
        StartCoroutine(MenuController.instance.WinPanelWSec(.8f));
    }
}
