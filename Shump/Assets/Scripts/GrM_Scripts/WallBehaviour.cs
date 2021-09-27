using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallBehaviour : MonoBehaviour
{
    private GameObject chosenChildren;
    private DalleBehaviour access;
    [SerializeField] private float timeBetweenActivation = 2;
    [SerializeField] private float timeBeforeNextActivation;
    [SerializeField] private float timeBetweenPush = 4;
    [SerializeField] private float timeBeforeNextPush;
    public List<GameObject> accessible;
    [SerializeField] private Material spawnerRed;
    [SerializeField] private Material yellowPush;
    
    public float speed = 0;
    
    void Start()
    {
        timeBeforeNextActivation = timeBetweenActivation;
        timeBeforeNextPush = timeBetweenPush;
        for (int i = 0; i < transform.childCount; i++)
        {
            accessible.Add(transform.GetChild(i).gameObject);   
        }
    }
    
    void Update()
    {
        if (accessible.Count > 0)
        {
            timeBeforeNextActivation -= Time.deltaTime;
            if (timeBeforeNextActivation < 0)
            {
                timeBeforeNextActivation = timeBetweenActivation;
                chosenChildren = accessible[Random.Range(0, accessible.Count)];
                accessible.Remove(chosenChildren);
                chosenChildren.GetComponent<MeshRenderer>().material = spawnerRed;
                access = chosenChildren.GetComponent("DalleBehaviour") as DalleBehaviour;
                access.spawner = true;
            }

            timeBeforeNextPush -= Time.deltaTime;
            if (timeBeforeNextPush < 0)
            {
                timeBeforeNextPush = timeBetweenPush;
                chosenChildren = accessible[Random.Range(0, accessible.Count)];
                accessible.Remove(chosenChildren);
                chosenChildren.GetComponent<MeshRenderer>().material = yellowPush;
                access = chosenChildren.GetComponent("DalleBehaviour") as DalleBehaviour;
                access.push = true;
                
            }
        }

        transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);


    }
}
