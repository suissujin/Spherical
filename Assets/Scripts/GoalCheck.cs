using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            ScoreCount.score += 1;
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
