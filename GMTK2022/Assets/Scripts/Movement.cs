using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
Rigidbody body;

float x;
float z;
float moveLimiter = 0.7f;

public float runSpeed = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (x != 0 && z != 0) 
        {
            x *= moveLimiter;
            z *= moveLimiter;
        }
        body.velocity = new Vector3(x * runSpeed, 0, z * runSpeed);
    }
}
