using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public KeyCode attackKey = KeyCode.Mouse0;

    public float attackSpeed = 1f;
    private float damage = 49f;
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
        if (CollisionDetection.isColliding)
        {
            //Damage all Objects of Enemy layer colliding with the sword radius
            foreach(Collider collider in CollisionDetection.colliders)
            {
                collider.gameObject.GetComponent<EnemyHealth>().Damage(damage);
            }
        }

    }
    void ResetAttack()
    {
        isReadyToAttack = true;
    }
}
