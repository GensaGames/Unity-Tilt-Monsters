using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public GameObject transparentBackground;
    public float transparentStep = 0.01f;
    public float repeatTime = 0.05f;
    public float startDelay = 0.0f;

    private Color currentColor;
    GameObject gameobject;
    void Start()
    {
        currentColor = transparentBackground.GetComponent<Renderer>().material.color;
        InvokeRepeating("updateTransparent", startDelay, repeatTime);
    }

    void updateTransparent()
    {
        if (currentColor.a < 0.8) 
        {
            currentColor.a += transparentStep;
            transparentBackground.GetComponent<Renderer>().material.color = currentColor;        
        }
     

    }
}
