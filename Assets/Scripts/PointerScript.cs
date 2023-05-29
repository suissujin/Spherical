using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.LookAt(GameObject.Find("MoonSpawner").transform.position);
    }
}
