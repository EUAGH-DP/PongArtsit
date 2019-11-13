using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Singleton Member Variables 0 
    /* This property makes this script a "singleton".
     This means when we do BallController.ballRef we get direct access to this script.
     We could then do something like 
     BallController.ballRef.gameObject.transform.position = Vector3.Zero;
     and put our position at (0, 0, 0). 
    */
    public static BallController ballRef;

    public GameObject hitGoalEffect;
    public Rigidbody2D _rigidbody2D;

    [SerializeField] float Speed = 1250f;


    void Start ()
    {
        ballRef = this;
    }



    public void ThrowBall ()
    {
        //x calculated to avoid up and down only
        var x = Random.Range(0.5f, 1f);
        if(Random.Range(0,2) == 1)
        {
            x *= -1;
        }
        var y = Random.Range(-1f, 1f);
        var direction = new Vector3(x, y, 0f);

        direction = direction.normalized * Speed;

        if (!_rigidbody2D)
            Debug.LogError("You forgot to set your RigidBody up on your ball! Make sure you do that, then try again!");

        _rigidbody2D.AddForce(direction, ForceMode2D.Force);
    }
    void OnTriggerEnter2D ( Collider2D hitObject )
    {
        //If we hit player 1's goal then player 2 scores.
        if (hitObject.gameObject.name == "Goal_Player1")
            GameManager.Score(GameManager.Player.Player2);
        //If we hit player 2's goal then player 1 scores.
        else if (hitObject.gameObject.name == "Goal_Player2")
            GameManager.Score(GameManager.Player.Player1);
    }
}