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
    public float movespeed = 5;
    


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
            Constraints();
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
        if(level2==true && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRb.AddForce(Vector3.forward * movespeed, ForceMode.Impulse);
            
            //transform.position = new Vector3(-12, 0, -1);
        }
        if (level2 == true && Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRb.AddForce(Vector3.back * movespeed, ForceMode.Impulse);
        }
    }
    public void Constraints()
    {
        if(transform.position.z < -10 )
        {
            transform.position = new Vector3(-12, 0, -10);
            playerRb.AddForce(Vector3.forward * movespeed, ForceMode.Impulse);
        }
        if(transform.position.z > -1)
        {
            transform.position = new Vector3(-12, 0, -1);
            playerRb.AddForce(Vector3.back * movespeed, ForceMode.Impulse);
        }
    }
   
}

