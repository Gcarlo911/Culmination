﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetmove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        position.x = position.x - .025f;
        this.transform.position = position;
        transform.Rotate(0, 0, 80 * Time.deltaTime);



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hiiii");
        Destroy(this.gameObject);
    }

}