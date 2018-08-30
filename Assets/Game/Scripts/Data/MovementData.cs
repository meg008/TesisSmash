using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementData
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumps;

    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
    }
    public int MaxJumps
    {
        get
        {
            return maxJumps;
        }
    }
}
