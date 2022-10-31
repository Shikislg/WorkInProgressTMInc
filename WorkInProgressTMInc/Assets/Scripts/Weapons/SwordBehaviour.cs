using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Mouse0;

    public float attackSpeed = 1f;
    bool isReadyToAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(attackKey) && isReadyToAttack)
        {
            isReadyToAttack = false;
            Attack();
            Invoke(nameof(ResetAttack),(1f/attackSpeed)-1f);
        }
    }

    void Attack()
    {
        //Debug.Log("Swing!");
        if (CollisionDetection.isColliding)
        {
            //Debug.Log("and Hit!");
        }
        else
        {
            //Debug.Log("and Miss!");
        }

    }
    void ResetAttack()
    {
        isReadyToAttack = true;
    }
}
