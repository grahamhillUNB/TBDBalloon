﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, -4, 0);
        rotateCow();
    }

    void rotateCow()
    {
        gameObject.transform.Rotate(0.0f, 0.0f, 0.7f, Space.Self);
    }
}
