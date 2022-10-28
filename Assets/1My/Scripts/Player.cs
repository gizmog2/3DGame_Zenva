using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rig;
    [SerializeField] float jumpForce;
    private bool isGrounded;

    
    void Update()
    {
        // get the horizontal and vertical inputs
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // set our velocity based on our inputs
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // create a copy of our velocity variable and set the Y axis to be 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // if we're moving, rotate to face our moving direction
        if (vel.x != 0 || vel.z != 0)
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }
}
