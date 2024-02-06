using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scheldwoord : MonoBehaviour
{
    public Spawning spawning;
    public float lifeTime;
    private float counter;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        counter += Time.deltaTime;
        if(counter > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().scheldwoord = gameObject;
            other.gameObject.GetComponent<Movement>().hitByScheldwoord = true;
        }
    }
}
