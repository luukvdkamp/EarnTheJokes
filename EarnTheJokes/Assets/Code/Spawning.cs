using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject scheldwoordCanvas;
    public GameObject[] scheldwoorden;
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

            int randomScheldwoord = Random.Range(0, 2);
            if(randomScheldwoord == 0)
            {
                GameObject scheldwoordPrefab = Instantiate(scheldwoorden[0], transform.position + new Vector3(spawnPosition, 0, 0), Quaternion.identity);
                scheldwoordPrefab.GetComponent<Scheldwoord>().spawning = GetComponent<Spawning>();
                scheldwoordenList.Add(scheldwoordPrefab);

                scheldwoordPrefab.transform.parent = scheldwoordCanvas.transform;
            }

            else
            {
                GameObject scheldwoordPrefab = Instantiate(scheldwoorden[1], transform.position + new Vector3(spawnPosition, 0, 0), Quaternion.identity);
                scheldwoordPrefab.GetComponent<Scheldwoord>().spawning = GetComponent<Spawning>();
                scheldwoordenList.Add(scheldwoordPrefab);

                scheldwoordPrefab.transform.parent = scheldwoordCanvas.transform;
            }
        }
    }
}
