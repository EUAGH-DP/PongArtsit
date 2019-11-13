using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public enum TypeOfController { Player, AI };

    public TypeOfController ControllerType;
    public float MovementSpeed = 10f;
    public float MaxYPosition = 15f;
    public float MinYPosition = -15f;
    public KeyCode UpKey;
    public KeyCode DownKey;


    void Update()
    {
        if (ControllerType == TypeOfController.AI)
        {
            if (!GameManager.GameStarted) return;

            if (transform.position.y < BallController.ballRef.transform.position.y)
                transform.position += Vector3.up * MovementSpeed;
            if (transform.position.y > BallController.ballRef.transform.position.y)
                transform.position += Vector3.down * MovementSpeed;
        }
        else
        {
            if (Input.GetKey(UpKey) && transform.position.y < MaxYPosition)
                transform.position += Vector3.up * MovementSpeed;
            if (Input.GetKey(DownKey) && transform.position.y > MinYPosition)
                transform.position += Vector3.down * MovementSpeed;
        }
    }
}