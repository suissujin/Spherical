using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    public ScoreCount scoreCount;
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = GameObject.Find("ScoreKeeper").GetComponent<ScoreCount>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            scoreCount.score += 1;
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
