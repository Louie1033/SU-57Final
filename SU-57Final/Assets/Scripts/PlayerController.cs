using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim; 

    public GameObject gameOverObject;
    public int score = 0;
    public bool level2;
    public float movespeed = 10000;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && level2 == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log("Jump");
            playerAnim.SetTrigger("Jump_trig");
            
        }
        if(level2 == true)
        {
            MoveSide();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameOver = true;
                Debug.Log("Game Over");
                gameOverObject.gameObject.SetActive(true);
            }
        
    }
    public void MoveSide()
    {
        if(level2==true && Input.GetKey(KeyCode.LeftArrow) && transform.position.x <= -1)
        {
            playerRb.AddForce(0,1,1 * movespeed, ForceMode.Impulse);
            Debug.Log("Left");
            //transform.position = new Vector3(-12, 0, -1);
        }
        if (level2 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(-12, 0, -10);
        }
    }
   
}

