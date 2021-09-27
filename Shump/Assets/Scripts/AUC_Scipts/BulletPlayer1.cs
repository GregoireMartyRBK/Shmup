using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 force = new Vector2(-1, 0);
        GetComponent<Rigidbody>().velocity = force * 15;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
}
