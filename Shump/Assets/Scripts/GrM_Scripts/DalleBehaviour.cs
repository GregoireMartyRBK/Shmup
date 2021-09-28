using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DalleBehaviour : MonoBehaviour
{
    [HideInInspector] public bool spawner = false;
    [HideInInspector] public bool push = false;
    private WallBehaviour accessList;
    private GameObject spawnedWall;

    [SerializeField] private Material baseMaterial;
    [SerializeField] private GameObject spawnable;
    

    private void OnCollisionEnter(Collision other)
    {
        
        if (spawner && other.gameObject.tag == "Bullet")
        {
            Spawn(Mathf.Sign(transform.position.x - other.transform.position.x));
        }
        else if (push && other.gameObject.tag == "Bullet")
        {
            Pushing(Mathf.Sign(transform.position.x - other.transform.position.x));
        }

        if (other.gameObject.tag != "RedPlayer" && other.gameObject.tag != "BluePlayer")
        {
            Destroy(other.gameObject);
        }
        else
        {
            transform.parent.GetComponent<WallBehaviour>().speed =
                transform.parent.GetComponent<WallBehaviour>().speed * -1;
            other.gameObject.GetComponent<HealthManager>().DamageDealt();
        }
        
    }

    void Spawn(float direction)
    {
        spawnedWall = Instantiate(spawnable,
            new Vector3(transform.position.x + 0.5f * direction, transform.position.y, transform.position.z),quaternion.identity);
        spawner = false;
        spawnedWall.GetComponent<PushedWallBehaviour>().speed = direction * 2;
        
        GetComponent<MeshRenderer>().material = baseMaterial;
        accessList = transform.parent.GetComponent("WallBehaviour") as WallBehaviour;
        accessList.accessible.Add(gameObject);
    }

    void Pushing(float direction)
    {
        
        GetComponent<MeshRenderer>().material = baseMaterial;
        push = false;
        accessList = transform.parent.GetComponent("WallBehaviour") as WallBehaviour;
        accessList.speed = (Mathf.Abs(accessList.speed)+0.05f) * direction;
        accessList.accessible.Add(gameObject);
        
    }
}
