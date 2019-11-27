using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will receive and manage all fired projectiles

public class ProjectileManager : MonoBehaviour
{
    List<GameObject> projectilesList = new List<GameObject>();
    PlayerControl playerControl;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1))
        {
            TriggerProjectile();
        }

        if (Input.GetMouseButtonDown(2))
        {
            DestroyLastProjectile();
        }
    }

    private void DestroyLastProjectile()
    {
        int projectileListLength = projectilesList.Count;

        if (projectileListLength != 0)
        {
            Destroy(projectilesList[projectileListLength - 1].gameObject);
            projectilesList.RemoveAt(projectileListLength - 1);
        }
    }

    private void TriggerProjectile()
    {
        int projectileListLength = projectilesList.Count;

        if (projectileListLength != 0)
        {
            if (projectilesList[projectileListLength - 1].tag == "Transponder")
            {
                var projectileTransform = projectilesList[projectileListLength - 1].transform.position;

                /* With the proximity checking we don't need the below adjustment anymore
                 * 
                 *Adjust player spawn position so we don't end up in the floor
                 *projectileTransform.y += 0.6f;
                 * 
                 */

                playerControl.TeleportPlayer(projectileTransform);
            }
            Destroy(projectilesList[projectileListLength - 1].gameObject);
            projectilesList.RemoveAt(projectileListLength - 1);
        }
    }

    public void AddToProjectileList(GameObject projectile)
    {
        projectilesList.Add(projectile);
    }


}
