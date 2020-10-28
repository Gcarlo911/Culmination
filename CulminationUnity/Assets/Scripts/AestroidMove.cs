using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AestroidMove : MonoBehaviour
{
    public enum EnemyType
    {
        Planet,
        Asteroid,
        Comet
    }

    public EnemyType enemyType;

    public float speed =2f;
    public int rotation = 100;
    public int damage = 1;
    
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if (gameObject.tag == "Planet") isPlanet = true;
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Vector3 position = this.transform.position;
      //  position.x = position.x - .05f;
        float movement = -1 * speed * Time.deltaTime;
        Vector3 xpos = new Vector3(movement, 0, 0);
        this.transform.position +=xpos;
        transform.Rotate(0, 0, rotation * Time.deltaTime);

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            manager.DescreseHealth(damage);
            //Destroy(this.gameObject);
        }
            
        if(collision.gameObject.tag == "LeftBoundery")
        {
            Destroy(this.gameObject);
        }

        if (enemyType == EnemyType.Planet)
        {
            if (collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Commet")
            {

                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }

        if (enemyType == EnemyType.Asteroid)
        {
            Destroy(this.gameObject);
        }

        if (enemyType == EnemyType.Comet)
        {
            if (collision.gameObject.tag == "Asteroid")
            {

                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }




        //Destroy(this.gameObject);
    }

}
