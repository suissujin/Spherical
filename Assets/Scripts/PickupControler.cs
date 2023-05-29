using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControler : MonoBehaviour
{
    public GameObject nRigidbody;
    public GameObject wRigidbody;

    void Start()
    {
        nRigidbody.SetActive(false);
        wRigidbody.SetActive(true);
    }
    void FixedUpdate()
    {
        if (wRigidbody.activeSelf && wRigidbody.transform.position != transform.position)
            wRigidbody.transform.position = transform.position;

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
