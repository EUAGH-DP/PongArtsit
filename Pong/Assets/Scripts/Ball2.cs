using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    public float Timer = 0;
    public float Spawn = 10;
    public bool Started = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameStarted)
        {
            if (!Started)
            {
                if (Timer >= Spawn)
                {
                    gameObject.GetComponent<Transform>().transform.position = GameManager.managerRef.ballStartPosition1;
                    gameObject.GetComponent<BallController>().ThrowBall();
                    Started = true;
                    Timer = 0;
                }
                else
                {
                    Timer += Time.deltaTime;
                }
            }
        }else
        {
            Timer = 0;
        }
    }
}
