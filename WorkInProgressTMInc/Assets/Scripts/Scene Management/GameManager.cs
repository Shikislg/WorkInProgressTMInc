using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerClass = 0;
    public static PlayerStats playerStats = new PlayerStats("Empty", 0, 0);
    void Start()
    {
        Debug.Log(Application.dataPath);
        switch (playerClass)
        {
            case 4: assignStats("Sheriff"); break;
            case 3: assignStats("Grenadier"); break;
            case 2: assignStats("Hawkeye"); break;
            case 1: assignStats("Predator"); break;
            case 0: assignStats("Predator");Debug.Log("No Class assigned. Falling back to default (Predator class)");break;
        }
    }
    void assignStats(string className)
    {
        string jsonRead = File.ReadAllBytes(Application.dataPath + "/Data/classData.json").ToString();
        playerStats = JsonUtility.FromJson<PlayerStats>(jsonRead);
        JsonUtility.FromJson<PlayerStats>(jsonRead);
    }
    public class PlayerStats
    {
        public string className;
        public int health;
        public int size;
        public PlayerStats(string pClassName, int pHealth, int pSize)
        {
            className = pClassName;
            health = pHealth;
            size = pSize;
        }
    }
}
