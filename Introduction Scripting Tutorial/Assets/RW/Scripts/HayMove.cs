﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMove : MonoBehaviour
{
    public Vector3 speed;
    public Space space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, space);
    }
}
