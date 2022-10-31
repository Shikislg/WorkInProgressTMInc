using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]  
public class EnemyHealth : MonoBehaviour
{
    public static float maxHealth;
    public static float health;
    public static bool isAlive = true;
    private Slider healthSlider;

    private void Update()
    {
        if (isAlive)
        {
            healthSlider = GetComponentInChildren<Slider>();
            healthSlider.value = health / maxHealth;
        }
    }




    public void Damage(float amount)
    {
        if (health < amount)
        {
            Kill();
        }
        else
        {
            health -= amount;
        }
    }
    public void Kill()
    {
        isAlive = false;
        CollisionDetection.colliders.Remove(GetComponent<Collider>());
        GameObject.Find(gameObject.name+"/EnemyDisplay").SetActive(false);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().velocity = new Vector3(Random.value, Random.value, Random.value);
    }
}
