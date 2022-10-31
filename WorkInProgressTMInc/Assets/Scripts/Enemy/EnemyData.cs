using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    //0 = Predator (default), 1 = Hawkeye...
    public static int enemyId = 0;

    public TextAsset textJSON;

    [System.Serializable]
    public class Enemy
    {
        public string name;
        public int health;
        public float damage;
    }

    [System.Serializable]
    public class EnemyList
    {
        public Enemy[] enemy;
    }

    public static EnemyList enemyList = new();

    void Start()
    {
        textJSON = Resources.Load("Data/enemyData") as TextAsset;

        enemyList = JsonUtility.FromJson<EnemyList>(textJSON.text);

        enemyId = getId();

        EnemyHealth.maxHealth = enemyList.enemy[enemyId].health;
        EnemyHealth.health = EnemyHealth.maxHealth;
    }

    int getId()
    {
        int count = 0;
        foreach(Enemy enemy in enemyList.enemy)
        {
            if (enemy.name.ToLower().Equals(this.gameObject.name.ToLower()))
            {
                return count;
            }
            count++;
        }
        return 0;
    }
}
