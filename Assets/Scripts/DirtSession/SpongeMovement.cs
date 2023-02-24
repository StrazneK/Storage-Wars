using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpongeMovement : MonoBehaviour
{
    [SerializeField] Transform sponge;
    float distanceToScreen;
    Vector3 posMove;
    private void Update()
    {
        distanceToScreen = Camera.main.WorldToScreenPoint(sponge.position).z;
        posMove = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
        sponge.position = new Vector3(posMove.x, posMove.y, posMove.z);
    }
}
