using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject asteroidPrefab;
    public GameObject commetPrefab;
    private float xSpawn = 12f;
    private float ySpawnMin = 5f;
    private float ySpawnMax = -5f;

    private float asteroidTimeTillSpawn;
    private float asteroidSpawnDelay = 1;

    private float planetTimeTillSpawn;
    private float planetSpawnDelay = 15;

    private float commetTimeTillSpawn;
    private float commetSpawnDelay = 8;

    private float asteroidInitialSpawnDelay=0;
    private float planetInitialSpawnDelay=15;
    private float commetInitialSpawnDelay=25;

    private int health = 100;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        asteroidTimeTillSpawn = asteroidInitialSpawnDelay;
        planetTimeTillSpawn = planetInitialSpawnDelay;
        commetTimeTillSpawn = commetInitialSpawnDelay;
    }
    
    // Update is called once per frame
    void Update()
    {

        healthText.text =  "Health: "+health.ToString();


        if (asteroidTimeTillSpawn <= 0)
        {
            Vector3 pos = new Vector3(xSpawn,Random.Range(ySpawnMin,ySpawnMax),0);
            Instantiate(asteroidPrefab,pos,Quaternion.identity);
            asteroidTimeTillSpawn = asteroidSpawnDelay;
        }
        else
        {
            asteroidTimeTillSpawn -= Time.deltaTime;
        }
        //////////////////

        if (planetTimeTillSpawn <= 0)
        {
            Vector3 pos = new Vector3(xSpawn, Random.Range(ySpawnMin, ySpawnMax), 0);
            Instantiate(planetPrefab, pos, Quaternion.identity);
            planetTimeTillSpawn = planetSpawnDelay;
        }
        else
        {
            planetTimeTillSpawn -= Time.deltaTime;
        }
        /////////////////////

        if (commetTimeTillSpawn <= 0)
        {
            Vector3 pos = new Vector3(xSpawn, Random.Range(ySpawnMin, ySpawnMax), 0);
            Instantiate(commetPrefab, pos, transform.rotation * Quaternion.Euler(0, 0, -35));
            commetTimeTillSpawn = commetSpawnDelay;
        }
        else
        {
            commetTimeTillSpawn -= Time.deltaTime;
        }
    }

    public void DescreseHealth(int value)
    {
        health -= value;
    }

}


