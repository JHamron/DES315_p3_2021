﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzBlade_rotation : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        transform.Rotate(Vector3.up, speed);
    }
}
