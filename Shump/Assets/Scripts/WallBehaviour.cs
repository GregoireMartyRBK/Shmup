using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    private GameObject chosenChildren;
    private DalleBehaviour access;
    [SerializeField] private float timeBetweenActivation = 2;
    [SerializeField] private float timeBeforeNextActivation;
    public List<GameObject> accessible;
    [SerializeField] private Material spawnerRed;
    
    void Start()
    {
        timeBeforeNextActivation = timeBetweenActivation;
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
        }

    }
}
