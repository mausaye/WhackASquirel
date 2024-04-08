using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    GameManager gm;
    private float jumpForce;

    private float speed;

    private Rigidbody rb;

    private float xMax = 6;
    private float xMin = -6;
    private float zMax = 9;
    private float zMin = -6;

    private float velocity = 10.0f;
    private float acc;
    private float accInit = -1;
    private float yPos;
    private bool jumping = false;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        this.speed = 10;
        this.jumpForce = 4;
        acc = accInit;
        yPos = this.gameObject.transform.position.y;

        this.rb = GetComponent<Rigidbody>();
       
    }

    void resetJump()
    {
        acc = accInit;
        velocity = 10;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded()) { jump(); }
            else { slam(); }

        }

        if(gm.isSlamming() && isGrounded())
        {
            StartCoroutine(delaySetSlam());
        }


        
       
    }

    private void FixedUpdate()
    {
        move();

        if (jumping)
        {
            velocity -= acc * Time.deltaTime;
            yPos += velocity;
            yPos *= Time.deltaTime;

            this.transform.Translate(0, yPos, 0);
        }
    }
    IEnumerator delaySetSlam()
    {
        yield return new WaitForSeconds(0.1f);
        gm.setIsSlamming(false);
    }

    void jump()
    {
        resetJump();
        jumping = true;

    }

    void slam()
    {
        jumping = false;
        this.rb.AddForce(Vector3.down * jumpForce * 2, ForceMode.Impulse);
        gm.setIsSlamming(true);
        
    }

    private void move()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        if (inBounds(movement))
            transform.Translate(movement);

    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false;
    }

    private bool isGrounded()
    {
        jumping = false;
        return Physics.Raycast(transform.position, -Vector3.up, 0.7f);
    }

    private bool inBounds(Vector3 delta)
    {
        var obj = this.transform.position;
        return (delta.x + obj.x < xMax && delta.x + obj.x > xMin && delta.z + obj.z < zMax && delta.z + obj.z > zMin);
    }

}
