using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOrbit : MonoBehaviour
{
    public float gravity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GravityCtrl>())
        {
            other.gameObject.GetComponent<GravityCtrl>().gravity = this.GetComponent<GravityOrbit>();
        }
    }
}
