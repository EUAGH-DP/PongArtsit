using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelOnDelay : MonoBehaviour
{
    [SerializeField] string NextLevel = "Player1";
    [SerializeField] float Delay = 0.1f;

    // this function is used by unity events to change the level after a specified delay
    public void ChangeScene()
    {
        StartCoroutine(DelayChange());
    }

    IEnumerator DelayChange()
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(NextLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
