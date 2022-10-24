using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerStats
{
    public static int walkSpeed = 7;
    public static int sprintSpeed = 10;
    public static int playerHeight = 2;
    public static int jumpForce = 8;
    public static float jumpCooldown = 0.25f;
    public static float airMultiplier = 0.3f;

    private static readonly PlayerStats instance = new PlayerStats();
    static PlayerStats()
    {

    }
    public static PlayerStats Instance
    {
        get
        {
            return instance;
        }
    }
}
