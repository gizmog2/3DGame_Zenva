using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{    
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rig;
    [SerializeField] float jumpForce;
    [SerializeField] int score;
    [SerializeField] Ui ui;

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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump.");
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
