using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // private int m_Score = 0;
    public float m_Speed;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 rotation = new Vector3(0, moveHorizontal, 0);


        rb.AddForce(movement * m_Speed);
        rb.AddTorque(rotation * m_Speed);
    }




}
