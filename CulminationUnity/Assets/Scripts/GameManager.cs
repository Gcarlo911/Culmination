using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject planetPrefab;
    public GameObject asteroidPrefab;
    public GameObject commetPrefab;
    public GameObject gameOver;
    public GameObject player;
    private float xSpawn = 16f;
    private float ySpawnMin = 5f;
    private float ySpawnMax = -5f;

    private float asteroidTimeTillSpawn;
    private float asteroidSpawnDelay = 1;

    private float planetTimeTillSpawn;
    private float planetSpawnDelay = 20;

    private float commetTimeTillSpawn;
    private float commetSpawnDelay = 10;

    private float asteroidInitialSpawnDelay=0;
    private float planetInitialSpawnDelay=30;
    private float commetInitialSpawnDelay=50;

    private int health = 100;
    private float scoreTimer = 0;
    private float score = 0;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    private bool gameOverCheck;
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
        scoreText.text = "Score: " + score;


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

        if (gameOverCheck == false)
        {
            scoreTimer += Time.deltaTime;
            score = (int)(scoreTimer);

        }



        if (score > 100) { asteroidSpawnDelay = .5f; }



        if (score >= 100 && score <= 102) { commetSpawnDelay = .2f; }
        else commetSpawnDelay = 10;


        if (health <= 0)
        {
            //SceneManager.LoadScene("GameOver");
            gameOverCheck = true;
            Destroy(player);
            gameOver.SetActive(true);
            finalScoreText.text = "Final Score: " + score.ToString(); 

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
                
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void DescreseHealth(int value)
    {
        health -= value;
    }
    
}


