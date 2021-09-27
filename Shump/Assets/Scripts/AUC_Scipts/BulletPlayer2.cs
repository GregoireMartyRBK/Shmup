using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer2 : MonoBehaviour
{
    void Start()
    {
        Vector2 force = new Vector2(1, 0);
        GetComponent<Rigidbody2D>().velocity = force * 15;
    }
}
