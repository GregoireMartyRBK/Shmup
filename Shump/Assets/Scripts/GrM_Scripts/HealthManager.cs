using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 3;
    public Image[] livesrepresentation;
    [SerializeField] private Animation anim;
    [SerializeField] private Animator animatord;

    private bool damageable;
    [SerializeField] private float invulnerabilityTime = 0.5f;
    private float invulnerabilityCounter;

    private void Start()
    {
        invulnerabilityCounter = invulnerabilityTime;
    }

    private void Update()
    {
        if (!damageable)
        {
            invulnerabilityCounter -= Time.deltaTime;
            if (invulnerabilityCounter < 0)
            {
                invulnerabilityCounter = invulnerabilityTime;
                damageable = true;
            }
        }
    }

    public void DamageDealt()
    {
        if (damageable)
        {
            damageable = false;
            if (gameObject.tag == "BluePlayer")
            {
                animatord.SetTrigger("DamageDealtBlue");
            }

            if (gameObject.tag == "RedPlayer")
            {
                animatord.SetTrigger("DamageDealtRed");
            }

            health--;
            for (int i = 0; i < livesrepresentation.Length; i++)
            {
                if (i > health - 1)
                {
                    livesrepresentation[i].enabled = false;
                }
                else
                {
                    livesrepresentation[i].enabled = true;
                }
            }
        }
    }
}
