using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public List<GameObject> moonList;
    public GameObject moon;
    private Vector3 lastPos;
    public float spawnRadiusVer = 5f;
    public float spawnRadiusHor = 10f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; ++i)
        {
            SpawnObject();
            transform.position -= new Vector3(36, 0, 0);
        }
    }

    void SpawnObject()
    {
        GameObject newMoon = Instantiate(moon);
        do
        {
            newMoon.transform.position = transform.position + Random.insideUnitSphere * 52;
            Debug.Log("generating new moon " + newMoon.transform.position + " lastpos " + lastPos + " distance " + Vector3.Distance(newMoon.transform.position, lastPos));
            //moonList.Add(newMoon);
        } while (Vector3.Distance(newMoon.transform.position, lastPos) < 37 || Vector3.Distance(newMoon.transform.position, lastPos) > 50);
        Debug.Log("final generating new moon " + newMoon.transform.position + "  lastpos " + lastPos + " distance " + Vector3.Distance(newMoon.transform.position, lastPos));
        lastPos = newMoon.transform.position;
    }
}
