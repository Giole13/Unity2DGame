using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 2.0f;
    public float spawnRateMax = 3.0f;

    public Transform targetTransform = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;
    // Start is called before the first frame update
    void Start()
    {
        spawnRateMin = 5f;
        spawnRateMax = 6f;

        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMin);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeAfterSpawn = timeAfterSpawn + Time.deltaTime;

        if(spawnRate <= timeAfterSpawn){
            // Reset point
            timeAfterSpawn = 0f;
            spawnRate = Random.RandomRange(spawnRateMin, spawnRateMax);

            GameObject bullet = Instantiate(bulletPrefab,
            transform.position, transform.rotation);
            bullet.transform.LookAt(targetTransform);
        }
            gameObject.transform.LookAt(targetTransform);
    }
}
