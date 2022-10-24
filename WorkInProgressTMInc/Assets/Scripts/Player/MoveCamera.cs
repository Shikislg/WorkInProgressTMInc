using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    // Start is called before the first frame update
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
