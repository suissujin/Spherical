using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    private CharacterCtrl character;

    private void Awake()
    {
        character = GameObject.Find("Player").GetComponent<CharacterCtrl>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            ScoreCount.score += 1;
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
            character.pickupHeld = false;

        }
    }
}
