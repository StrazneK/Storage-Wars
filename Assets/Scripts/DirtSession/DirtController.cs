using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtController : MonoBehaviour
{
    int dirtCount = 0;
    void Start()
    {
        AddDirtComponents();
    }
    void AddDirtComponents()
    {
        dirtCount = transform.childCount;
        for (int i = 0; i < dirtCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.AddComponent<Rigidbody>();
            child.GetComponent<Rigidbody>().useGravity = false;

            child.AddComponent<BoxCollider>();
            BoxCollider childCollider = child.GetComponent<BoxCollider>();
            childCollider.size = new Vector3(childCollider.size.x, childCollider.size.y, 1000);
            child.GetComponent<BoxCollider>().size = childCollider.size;

            child.tag = "Dirt";
            child.layer = 6;
        }
    }

    public bool CleanDirt(GameObject dirt)
    {
        dirt.GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(DirtDestroy(dirt));
        dirtCount--;
        dirt.tag = "Finish";
        return dirtCount < 2;
    }

    IEnumerator DirtDestroy(GameObject dirt)
    {
        yield return new WaitForSeconds(1);
        Destroy(dirt);
    }
}
