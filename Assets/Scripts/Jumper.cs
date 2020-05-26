using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce = 6.5f;
    [Tooltip("The magnitude of the force to add in each frame, in newtons.")]
    [SerializeField] float forceSize = 5f;

    [Tooltip("Force = continuous & mass; Acceleration = continuous & no mass; Impulse = instant & mass; VelocityChange = instant & no mass.")]
    [SerializeField] ForceMode2D forceMode = ForceMode2D.Force;

    [SerializeField] bool isGrounded = true;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector3(horizontal * forceSize, 0, 0), forceMode);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "platform" || collision.gameObject.tag == "wall")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "platform" && collision.gameObject.tag != "wall")
            isGrounded = false;
    }

    public void Jump()
    {
        Vector3 up = new Vector3(0, 1f, 0);//transform.TransformDirection(Vector3.up);
        rb.AddForce(up * jumpForce, ForceMode2D.Impulse);
    }
}
