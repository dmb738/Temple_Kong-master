using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{

    public GameObject spikes;
    public float spawnTime;
    private float rando;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnTimeDelay());
        Instantiate(spikes, transform.position, Quaternion.identity);
    }
    IEnumerator SpawnTimeDelay()
    {
        while (true)
        {
            rando = Random.value;
            if (rando > .2)
            {
                Instantiate(spikes, transform.position, Quaternion.identity);
            }
            spawnTime = Random.Range(4.0f, 7.0f);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}