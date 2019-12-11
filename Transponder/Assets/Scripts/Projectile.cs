using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is concerned with creating and firing off projectiles, including any charge-ups etc
// After firing, object gets stored in ProjectileManager class

public class Projectile : MonoBehaviour
{
    //Array of all available projectile types
    [SerializeField]
    GameObject[] projectileType = new GameObject[2];

    //public bool isWeaponActive { get; set; }

    public bool isWeaponActive;
    public float weaponMaxCharge = 5f;
    public float weaponMinCharge = 5f;
    private float weaponCharge;
    public float weaponChargeRate = 0.2f;
    ProjectileManager projectileMan;
    public Transform projectileSpawnLocation;


    private int currentProjectile = 0;
    
    void Start()
    {
        weaponCharge = weaponMinCharge;
        projectileMan = FindObjectOfType<ProjectileManager>();
        
    }
    void Update()
    {
       if (Input.GetMouseButtonUp(0) && !Pause_Menu.gameIsPaused)
        {
            weaponFire();
        }

        if (Input.GetMouseButton(0) && !Pause_Menu.gameIsPaused)
        {
            weaponChargeUp();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward scrolling
        {
            WeaponCycle(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards scrolling
        {
            WeaponCycle(-1);
        }

    }

    private void WeaponCycle(int scrollDir)
    {
        if (scrollDir == 1)
        {
            currentProjectile++;
            if (currentProjectile > projectileType.Length - 1)
            {
                currentProjectile = 0;
                
            }
            Debug.Log(projectileType[currentProjectile].tag);
        }
        else if (scrollDir == -1)
        {
            currentProjectile--;
            if (currentProjectile < 0)
            {
                currentProjectile = projectileType.Length - 1;
                
            }
            Debug.Log(projectileType[currentProjectile].tag);
        }
    }

    public void weaponChargeUp()
    {
        if (weaponCharge <= weaponMaxCharge) weaponCharge += weaponChargeRate;

    }

    public void weaponFire()
    {
        
        var proj = Instantiate(projectileType[currentProjectile], projectileSpawnLocation.position, this.transform.rotation);
        proj.GetComponent<Rigidbody>().AddRelativeForce(0, 0, weaponCharge, ForceMode.Impulse);
        weaponCharge = weaponMinCharge;

        projectileMan.AddToProjectileList(proj);
    }


}
