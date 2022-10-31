using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //0 = Predator (default), 1 = Hawkeye...
    public static int classId = 0;

    public TextAsset textJSON;

    [System.Serializable]
    public class Player
    {
        public string name;
        public int health;
        public float size;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] player;
    }
  
    public static PlayerList playerList = new();

    void Start()
    {
        textJSON = Resources.Load("Data/classData") as TextAsset;

        playerList = JsonUtility.FromJson<PlayerList>(textJSON.text);

        PlayerHealth.maxHealth = playerList.player[classId].health;
        PlayerHealth.health = PlayerHealth.maxHealth;
        Debug.Log(PlayerHealth.maxHealth);
    }
}
