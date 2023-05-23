using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerController PlayerControllerScript;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerScript.gameOver == false)
        {
            Score();
        }
    }
    public void Score()
    {
        score += Time.deltaTime * 1.2f;
        scoreText.text = "Score: " + Mathf.Round(score);
    }
}
