using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public Text speedDisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        speedDisplay = GameObject.Find("HealthDisplay").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        speedDisplay.text = "Health: " + PlayerHealth.health;
    }
}
