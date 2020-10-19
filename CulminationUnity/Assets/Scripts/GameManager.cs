using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject asteroidPrefab;
    public GameObject commetPrefab;
    private float xSpawn = 10f;
    private float ySpawnMin = 3.8f;
    private float ySpawnMax = -3.8f;
    private float timeTillSpawn;
    private float spawnDelay=2;
    private int health = 100;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        timeTillSpawn =spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text =  "Health: "+health.ToString();


        if (timeTillSpawn <= 0)
        {
            Vector3 pos = new Vector3(xSpawn,Random.Range(ySpawnMin,ySpawnMax),0);
            Instantiate(asteroidPrefab,pos,Quaternion.identity);
            timeTillSpawn = spawnDelay;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;
        }
    }

    public void DescreseHealth()
    {
        health -= 1;
    }

}


