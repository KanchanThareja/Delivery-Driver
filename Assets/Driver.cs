using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float translateSpeed = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float translateAmount = Input.GetAxis("Vertical") * translateSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,translateAmount,0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "powerUp")
        {
            translateSpeed += 1f;
            speed += 0.01f;
        }
    }

    void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.tag == "block")
        {
            translateSpeed -= 1f;
            speed -= 0.01f;
        }
    }
}
