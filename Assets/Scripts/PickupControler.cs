using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControler : MonoBehaviour
{
    public GameObject nRigidbody;
    public GameObject wRigidbody;
    public GameObject grabTrigger;

    void Start()
    {
        nRigidbody.SetActive(false);
        wRigidbody.SetActive(true);
    }
    void FixedUpdate()
    {
        if (wRigidbody.activeSelf && wRigidbody.transform.position != transform.position)
        {
            grabTrigger.transform.position = wRigidbody.transform.position;
        }
        Debug.Log("My cute pickup is at " + transform.position);
        Debug.Log("Has rigidbody: " + wRigidbody.activeSelf);
    }
    public void pickUpHeld()
    {
        transform.position = wRigidbody.transform.position;
        nRigidbody.SetActive(true);
        wRigidbody.SetActive(false);
    }
    public void pickUpDropped()
    {
        wRigidbody.transform.position = transform.position;
        nRigidbody.SetActive(false);
        wRigidbody.SetActive(true);
    }
}
