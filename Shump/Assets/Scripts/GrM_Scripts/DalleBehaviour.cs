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

    [SerializeField] private Material baseMaterial;
    [SerializeField] private GameObject spawnable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && spawner)
        {
            Spawn(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) && spawner)
        {
            Spawn(1);
        }
        else if (Input.GetKeyDown(KeyCode.A) && push)
        {
          Pushing(-1);  
        }
        else if (Input.GetKeyDown(KeyCode.E) && push)
        {
            Pushing(1);
        }
    }

    void Spawn(int direction)
    {
        Instantiate(spawnable,
            new Vector3(transform.position.x + 3 * direction, transform.position.y, transform.position.z),quaternion.identity);
        spawner = false;
        GetComponent<MeshRenderer>().material = baseMaterial;
        accessList = transform.parent.GetComponent("WallBehaviour") as WallBehaviour;
        accessList.accessible.Add(gameObject);
    }

    void Pushing(int direction)
    {
        
        GetComponent<MeshRenderer>().material = baseMaterial;
        push = false;
        accessList = transform.parent.GetComponent("WallBehaviour") as WallBehaviour;
        accessList.speed = (Mathf.Abs(accessList.speed)+0.05f) * direction;
        accessList.accessible.Add(gameObject);
        
    }
}
