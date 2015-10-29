using UnityEngine;
using System.Collections;

public class StaticSceneManager : MonoBehaviour {

    public GameObject setSpawnToDestroy;
    public int timeToDestroy = 5;

    private float timer = 0;
    private bool timerIsWork = true;
	void Start () {

	}
	
	void Update () {
        if (timerIsWork)
            setTimerAction();
	}

    void setTimerAction()
    {
        timer += Time.deltaTime;
        int decimalValue = Mathf.RoundToInt(timer);
        if (decimalValue >= timeToDestroy)
        {
            Destroy(setSpawnToDestroy);
            timerIsWork = false;
        } 
    }
}
