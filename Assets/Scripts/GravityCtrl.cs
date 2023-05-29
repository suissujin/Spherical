using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCtrl : MonoBehaviour
{

    public GravityOrbit gravity;
    private Rigidbody rb;
    public bool gravityOn = true;

    public float rotationSpeed = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gravity != null && gravityOn)
        {
            Vector3 gravityUp = Vector3.zero;
            gravityUp = (transform.position - gravity.transform.position).normalized;

            Vector3 localUp = transform.up;
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            //rb.rotation = targetRotation;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.AddForce((-gravityUp * gravity.gravity) * rb.mass);
        }
    }
}
