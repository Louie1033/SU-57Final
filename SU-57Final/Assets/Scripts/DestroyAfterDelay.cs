using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float delayDestory;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayDestory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
