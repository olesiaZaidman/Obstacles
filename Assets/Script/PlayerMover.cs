using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody body;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float speed = 1000f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //Vector3 position = body.position;
        //position.xCubeCoordinate = position.xCubeCoordinate + horizontalInput * speed * Time.deltaTime;
        //position.z = position.z + verticalInput * speed * Time.deltaTime;
        //body.MovePosition(position);
        //Debug.Log("position: " + position);

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Apply velocity to the Rigidbody
        body.velocity = movement * speed * Time.fixedDeltaTime;
    }
}
