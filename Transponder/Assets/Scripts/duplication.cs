﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplication : MonoBehaviour
{

    Projectile projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        projectile = FindObjectOfType<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        projectile.weaponFire();
    }
}
