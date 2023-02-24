using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dirt")
        {
            if (other.transform.parent.GetComponent<DirtController>().CleanDirt(other.gameObject))
            {
                DirtyObjController.instance.SuccessClean();
            }
        }
    }
}
