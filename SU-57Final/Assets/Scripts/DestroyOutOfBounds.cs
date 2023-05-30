using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public PlayerController PlayerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(PlayerControllerScript.level2 != true)
        {
            OutOfBounds();
        }
        if(PlayerControllerScript.level2 == true)
        {
            Level2OutofBounds();
        }
        */
    }
    /*void OutOfBounds()
    {
        if(transform.position.x <= -3f)
        {
            Destroy(gameObject);
        }
    }
    void Level2OutofBounds()
    {
        if (transform.position.x <= -45f)
        {
            Destroy(gameObject);
        }
    }
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
        }
}
