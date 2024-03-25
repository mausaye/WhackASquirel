using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpForce;

    private float speed;

    private Rigidbody rb;

    private bool inAir;

    // Start is called before the first frame update
    void Start()
    {
        this.speed = 20;
        this.jumpForce = 8;

        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded()) { jump(); }
            else { slam(); }

        }

        move();
    }

    void jump()
    {
        this.rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void slam()
    {
        this.rb.AddForce(Vector3.down * jumpForce * 2, ForceMode.Impulse);
        
    }

    private void move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical")  * speed;

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        this.rb.AddForce(movement * speed * Time.deltaTime);
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.6f);
    }
}
