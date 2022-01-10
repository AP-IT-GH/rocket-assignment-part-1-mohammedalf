using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float direction = 50f;
    [SerializeField] float upspeed = 200f;
    bool up;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        up = Input.GetKey(KeyCode.Space);
        float tilt = Input.GetAxis("Horizontal");

        if (!Mathf.Approximately(tilt, 0f))
        {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * direction * Time.deltaTime))));
        }

        rb.freezeRotation = false;
    }

    private void FixedUpdate()
    {
        if (up)
        {
            rb.useGravity = false;
            rb.AddRelativeForce(Vector3.up * upspeed * Time.deltaTime);
        }
        else
        {
            rb.useGravity = true;
        }
    }
}
