using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeapon : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<GameObject>().transform.rotation = this.transform.rotation;
    }
}
