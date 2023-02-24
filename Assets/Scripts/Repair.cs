using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    bool isStart = true;
    bool inRepair = false;
    bool repaired = false;
    [SerializeField] Animator anim;
    private void Start()
    {
        anim.enabled = false;
    }
    private void Update()
    {
        if (isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!inRepair && !repaired)
                {
                    inRepair = true;
                    CameraController.instance.ChangeCamera();
                    anim.enabled = true;
                }
                else if (inRepair)
                {
                    anim.enabled = true;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (inRepair)
                    anim.enabled = false;

            }
        }
    }
    public void CloseAnim()
    {
        inRepair = false;
        repaired = true;
        CameraController.instance.ChangeCamera();
        StartCoroutine(FinishScene());
    }
    IEnumerator FinishScene()
    {
        yield return new WaitForSeconds(1f);
        CameraController.instance.PlayConfetti();
        yield return new WaitForSeconds(2.5f);
        LevelController.instance.NextLevel();
    }
}
