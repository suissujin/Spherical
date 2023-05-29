using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehaviour : MonoBehaviour
{
    public int moonType;
    public GameObject pickUp;
    public GameObject Goal;
    public float moonSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(FastMoon());
        moonType = Random.Range(0, 10);

        if (moonType >= 0 && moonType <= 5)
        {
            moonType = 0;
        }
        else if (moonType >= 5 && moonType <= 10)
        {
            moonType = Random.Range(1, 3);
        }
        switch (moonType)
        {
            case 0: // white
                GetComponent<Renderer>().material.color = Color.white;
                break;
            case 1: // red
                GetComponent<Renderer>().material.color = Color.red;
                GameObject newPickUp = Instantiate(pickUp, transform.position + Random.onUnitSphere * 10, Quaternion.identity);
                newPickUp.transform.parent = transform;
                break;
            case 2: // blue   
                GetComponent<Renderer>().material.color = Color.blue;
                GameObject newGoal = Instantiate(Goal, transform.position + Random.onUnitSphere * 10, Quaternion.identity);
                newGoal.transform.parent = transform;
                break;
            default:
                break;
        }
    }
    private void FixedUpdate()
    {
        // Debug.Log("Moon Speed: " + moonSpeed);
        MoveMoon();
    }

    private void MoveMoon()
    {
        transform.position += new Vector3(1, 0, 0) * moonSpeed * Time.deltaTime;
    }

    IEnumerator FastMoon()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            moonSpeed += 1f;
        }
    }
}
