using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushedWallBehaviour : MonoBehaviour
{
    public float speed;

    
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime*speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedPlayer" || other.gameObject.tag == "BluePlayer")
        {
            other.gameObject.GetComponent<HealthManager>().DamageDealt();
        }
        Destroy(gameObject);
    }
}
