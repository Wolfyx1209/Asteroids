using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Update()
    {
        //Debug.DrawLine(new Vector3(0,0,0), new Vector3(0,0,1), Color.green, 1000);
        
    }

    private void Spawn()
    {
        for (var i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            var spawnPoint = transform.position + spawnDirection;

            var variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            var rotation = Quaternion.AngleAxis(variance, Vector3.forward); // не понял
            // Debug.DrawLine(Vector3.forward, Vector3.forward*10, Color.green, 1000);
            var asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minsize, asteroid.maxsize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
