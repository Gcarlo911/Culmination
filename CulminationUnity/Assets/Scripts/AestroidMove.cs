using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AestroidMove : MonoBehaviour
{

    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = position.x - .05f;
        this.transform.position = position;
        transform.Rotate(0, 0, 100 * Time.deltaTime);

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //variable health stuff
            manager.DescreseHealth();

        }
        
        Destroy(this.gameObject);
    }

}
