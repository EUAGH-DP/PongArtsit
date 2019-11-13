using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //This represents our players in our game. For our purposes we will be only be using 1 and 2. 
    public enum Player
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    //Singleton Member Variables 
    /* This property makes this script a "singleton".
       This means when we do GameManager.managerRef we get direct acces to this script.
       We could then do something like
      GameManager.managerRef.gameObject.transform.position = Vector3.Zero; and put our 
       position at (0, 0, 0). 
    */
    public static GameManager managerRef;
   
    //Has the game started? 
    public static bool GameStarted = false;

    //These represent the UI text objects displayed on screen.
    [SerializeField] Text scoreObject_P1 = null;
    [SerializeField] Text scoreObject_P2 = null;

    //These represent the scores our players have.
    [SerializeField] int score_P1 = 0;
    [SerializeField] int score_P2 = 0; 

    //This is how many points are earned when a goal is reached.
    [SerializeField] int scorePerGoal = 1;

    //This is the position the ball will start at.
    [SerializeField] Vector3 ballStartPosition = new Vector3();
	
	//events to run on player deaths
	[SerializeField] UnityEvent Player1Events = new UnityEvent();
	[SerializeField] UnityEvent Player2Events = new UnityEvent();

    void Start ( ) 
    {
        if (!scoreObject_P1)
            Debug.LogError("Make sure you set the Score Object P1 on the GameManager to the correct text object!");
        if (!scoreObject_P2)
            Debug.LogError("Make sure you set the Score Object P2 on the GameManager to the correct text object!");
        //Set our reference. 
        managerRef = this;
        //Set the game to not be started.
        GameStarted = false;
    }


    void Update ( )
    {
        if(!GameStarted)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                BallController.ballRef.ThrowBall();
                GameStarted = true;
            }
        }
    }


    public static void Score ( Player player)
    {
        switch ( player )
        {
            case Player.Player1:
                managerRef.score_P1 += managerRef.scorePerGoal;
				if(managerRef.score_P1 >= 11)
				{
                    managerRef.Player1Events.Invoke();
				}
                break;
            case Player.Player2:
                managerRef.score_P2 += managerRef.scorePerGoal;
				if(managerRef.score_P2 >= 11)
				{
                    managerRef.Player2Events.Invoke();
				}
                break;
        }

        //Update the player score objects to display the current player scores.
        managerRef.scoreObject_P1.text = $"{ managerRef.score_P1 }";
        managerRef.scoreObject_P2.text = $"{ managerRef.score_P2 }"; 

        GameStarted = false;
        BallController.ballRef.gameObject.transform.position = managerRef.ballStartPosition;
        BallController.ballRef._rigidbody2D.velocity = Vector3.zero;
    }
}