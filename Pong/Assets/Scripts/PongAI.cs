using System.Collections;
using System. Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    
    public float MovementSpeed = 10f; void Update()
    {
        if (!GameManager.GameStarted) return;
        if (transform.position.y < BallController.ballRef.transform.position.y)
            transform.position += Vector3.up * MovementSpeed;
        if (transform.position.y > BallController.ballRef.transform.position.y)
            transform.position += Vector3.down * MovementSpeed;

    }
}