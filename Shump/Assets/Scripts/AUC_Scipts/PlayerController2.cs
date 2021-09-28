using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed;
    public bool readyToShoot;
    [SerializeField] private float resetShoot;
 
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (Input.GetKey(KeyCode.D) )
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q)&& transform.position.x > -8.15)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S) && transform.position.y > - 3.7)
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Z) && transform.position.y < 3.7)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Player 2 : X Button Pressed");
            if(readyToShoot)
                Shoot();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
            Debug.Log("Player 2 : A Button Pressed");
    }
    
    private void Shoot()
    {
        readyToShoot = false;
        ObjectPooler.Instance.SpawnFromPool("Player2_Bullet", transform.GetChild(0).position, Quaternion.identity);
        Invoke(("ResetShoot"), resetShoot);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}

