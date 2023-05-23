using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        enemyAnim = GetComponent<Animator>();
        enemyAnim.speed = .8f;
    }

    // Update is called once per frame
    void Update()
    {
        GameOverSequence();
    }
    public void GameOverSequence()
    {
        if (playerControllerScript.gameOver == true && transform.position.x <= -2f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 4);
        }
        if(transform.position.x >= -2)
        {
            enemyAnim.SetFloat("Speed_f", .09f);
            enemyAnim.SetBool("Eat_b", true);
        }
    }
}
