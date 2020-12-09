using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generationcontroller : MonoBehaviour
{
    [SerializeField] private GameObject[] AsteroidPrefabs;
    [SerializeField] private int spawnRate = 3000;
    void Start()
    {
        SpawnAsteroids(spawnRate);
    }
    private void SpawnAsteroids(int amount) 
    {
        for (int i=0; i < amount; i++) 
        {
            Vector3 pos = new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), Random.Range(300, 300));
            GameObject chosenAsteroid = AsteroidPrefabs[Random.Range(0, AsteroidPrefabs.Length)];
            chosenAsteroid.name = "Asteroid";
            GameObject asteroid = Instantiate(chosenAsteroid , pos, Quaternion.identity);
            // You can still manipulate asteroid afterwards like .AddComponent etc
        }
    }
}
