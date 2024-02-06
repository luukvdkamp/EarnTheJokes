using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject scheldwoordCanvas;
    public GameObject scheldwoorden;
    public List<GameObject> scheldwoordenList = new List<GameObject>();
    public float spawnDelay;
    private float spawnCounter;
    public int spawnRange;


    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter > spawnDelay)
        {
            spawnCounter = 0;

            int spawnPosition = Random.Range(-spawnRange, spawnRange);
            GameObject scheldwoordPrefab = Instantiate(scheldwoorden, transform.position + new Vector3(spawnPosition, 0, 0), Quaternion.identity);
            scheldwoordPrefab.GetComponent<Scheldwoord>().spawning = GetComponent<Spawning>();
            scheldwoordenList.Add(scheldwoordPrefab);

            scheldwoordPrefab.transform.parent = scheldwoordCanvas.transform;
        }
    }
}
