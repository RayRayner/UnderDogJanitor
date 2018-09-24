using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int playerSpeed;
    public int jumpHeight;
    public float jumpCoolDown;

    Rigidbody rb;

    bool jump = true;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hackey Movement for init
        if (Input.GetAxis("Horizontal") > 0.1 && jump)
        {
            rb.AddForce(Vector3.right * playerSpeed, ForceMode.Impulse);
        }
        if (Input.GetAxis("Horizontal") < -0.1 && jump)
        {
            rb.AddForce(Vector3.left * playerSpeed, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") > 0.1 && jump)
        {
            rb.AddForce(Vector3.forward * playerSpeed, ForceMode.Impulse);
        }
        if (Input.GetAxis("Vertical") < -0.1 && jump)
        {
            rb.AddForce(Vector3.back * playerSpeed, ForceMode.Impulse);
        }
        //Hackey Jump
        if (Input.GetAxis("Jump") > 0.1 && jump)
        {
            rb.drag = 0;
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            StartCoroutine("resetJump");
            jump = false;
        }
    }
    //Creating a jump cycle so you cant fly up
    IEnumerator resetJump()
    {
        yield return new WaitForSeconds(jumpCoolDown);
        rb.drag = 5;

        jump = true;
    }
}
