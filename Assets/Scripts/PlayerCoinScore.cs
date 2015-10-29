using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCoinScore : MonoBehaviour
{
    
    public GameObject scoreUI;
    public GameObject coinScoreUI;

    public GameObject damageEffect;
    public float destroyEffectIn = 0.5f;

    public int increaseScore = 10;

    public int blueScore = 10;
    public int orangeScore = 50;
    public int pinkScore = 200;

    public int bombDecrease = 300;

    public GameObject coinText;
    public GameObject CanvasGUI;

    public float destroyCoinText = 1f;
    public Material blueMaterial;
    public Material orangeMaterial;
    public Material pinkMaterial;

    private int score = 0;
    private int coinScore = 0;
    private float seconds = 0;
    private Text GUIText;
    void Start()
    {
       
    }

    void Update()
    {
        updateScore();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject collisionObject;
        collisionObject = collider.gameObject;
        GameObject gameText = new GameObject();

        switch (collisionObject.tag)
        {
            case "BlueCoin":
                Destroy(collisionObject);
                coinScore += blueScore;

                gameText = Instantiate(coinText, transform.position, transform.rotation) as GameObject;               
                gameText.transform.parent = CanvasGUI.transform;
                gameText.transform.localScale = new Vector3(1, 1, 1);
                Destroy(gameText, destroyCoinText);

                GUIText = gameText.GetComponent<Text>();
                GUIText.text = blueScore.ToString();
                GUIText.material = blueMaterial;
               
                break;

            case "OrangeCoin":

                Destroy(collisionObject);
                coinScore += orangeScore;

                gameText = Instantiate(coinText, transform.position, transform.rotation) as GameObject;
                gameText.transform.parent = CanvasGUI.transform;
                gameText.transform.localScale = new Vector3(1, 1, 1);
                Destroy(gameText, destroyCoinText);

                GUIText = gameText.GetComponent<Text>();
                GUIText.text = orangeScore.ToString();
                GUIText.material = orangeMaterial;

                break;

            case "PinkCoin":

                Destroy(collisionObject);
                coinScore += pinkScore;

                gameText = Instantiate(coinText, transform.position, transform.rotation) as GameObject;
                gameText.transform.parent = CanvasGUI.transform;
                gameText.transform.localScale = new Vector3(1, 1, 1);

                GUIText = gameText.GetComponent<Text>();
                GUIText.text = pinkScore.ToString();
                GUIText.material = pinkMaterial;

                Destroy(gameText, destroyCoinText);

                break;

            case "Bomb":
                Destroy(collisionObject);
                coinScore -= bombDecrease;

                Object prefabObject = new Object();
                prefabObject = Instantiate(damageEffect, transform.position, transform.rotation);
                Destroy(prefabObject, destroyEffectIn);
                break;

            default:

                break;

        }          

    }


    void updateScore() {
        seconds += Time.deltaTime * increaseScore;
        int decimalValue = Mathf.RoundToInt(seconds) ;
        scoreUI.GetComponent<Text>().text = "Score: " + decimalValue;
        coinScoreUI.GetComponent<Text>().text = ((int)(coinScore)).ToString();
    }
}
