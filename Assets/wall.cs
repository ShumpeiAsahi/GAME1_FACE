﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "blue" || other.gameObject.tag == "red")
        {
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
