using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hAxis;
    public float vAxis;
    public float moveSpeed = 30f;
    public bool readyToShoot;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Input.GetJoystickNames());
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
    }

    private void myInput()
    {
        hAxis = Input.GetAxis("Gamepad1_Horizontal");
        vAxis = Input.GetAxis("Gamepad1_Vertical");
        
        if (hAxis > 0.2)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (hAxis < -0.2)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (vAxis > 0.4)
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        if(vAxis < -0.4)
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        if (Input.GetAxis("Gamepad1_xButton") != 0)
        {
            Debug.Log("Player 1 : Button X Pressed !");
            if(readyToShoot)
                Shoot();
        }
        if(Input.GetAxis("Gamepad1_aButton") != 0)
            Debug.Log("Player 1 : Button A Pressed !");
    }
    private void Shoot()
    {
        readyToShoot = false;
        ObjectPooler.Instance.SpawnFromPool("Player1_Bullet", transform.GetChild(0).position, Quaternion.identity);
        Invoke(("ResetShoot"), 0.26f);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
