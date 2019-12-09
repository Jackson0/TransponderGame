using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProximityCheck
{
    Vector3 spawnPoint;
    bool canSpawn;

    // This is the size of the sphere used for Overlapsphere check
    float sphereCheckSize = 0.2f;
    // This is the distance between transponder and center of sphere used for Overlapsphere check
    float distanceFromSpawnPoint = 0.3f;
    // Height offset. Test a little above the transponder position to avoid all Overlapsphere tests colliding with floor
    float heightOffset = 0.5f;
    // List populated in constructor with all positions to check around the transponder
    List<Vector3> proximityTestDirection = new List<Vector3>();

    public SpawnProximityCheck(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;

        // All the points around the translocator I want to test for a possible spawnpoint
       
        // And with slight offset to below transponder. For when player tries to spawn just beneath a collider
        proximityTestDirection.Add(spawnPoint + new Vector3(0, -0.2f, 0));

        // Current transponder location checked first, adding 0.2f from original position for slight offset
        proximityTestDirection.Add(spawnPoint + new Vector3(0, heightOffset, 0));

        // Left, Right, Back, Front
        proximityTestDirection.Add(spawnPoint + new Vector3(-distanceFromSpawnPoint, heightOffset, 0));
        proximityTestDirection.Add(spawnPoint + new Vector3(distanceFromSpawnPoint, heightOffset, 0));
        proximityTestDirection.Add(spawnPoint + new Vector3(0, heightOffset, -distanceFromSpawnPoint));
        proximityTestDirection.Add(spawnPoint + new Vector3(0, heightOffset, distanceFromSpawnPoint));
        // Diagonal positions
        proximityTestDirection.Add(spawnPoint + new Vector3(-distanceFromSpawnPoint, heightOffset, distanceFromSpawnPoint));
        proximityTestDirection.Add(spawnPoint + new Vector3(distanceFromSpawnPoint, heightOffset, distanceFromSpawnPoint));
        proximityTestDirection.Add(spawnPoint + new Vector3(-distanceFromSpawnPoint, heightOffset, -distanceFromSpawnPoint));
        proximityTestDirection.Add(spawnPoint + new Vector3(distanceFromSpawnPoint, heightOffset, -distanceFromSpawnPoint));
        
    }
    
    public Vector3 validSpawnPoint()
    {
        //Debug.Log("Can Spawn at: " + spawnPoint);
        return spawnPoint;
    }

    public bool CanSpawnHere()
    {
        float radius = sphereCheckSize;
        bool canSpawnHere = true;

        GizmoDrawer.plotPoint.Clear();

        foreach (var item in proximityTestDirection)
        {
            GizmoDrawer.plotPoint.Add(item);

            canSpawnHere = true;
            Collider[] hitColliders = Physics.OverlapSphere(item, radius);

            foreach (var collider in hitColliders)
            {
                if (collider.gameObject)
                {
                    if (collider.gameObject.layer != 10 &&
                        collider.gameObject.layer != 11)
                    {
                        //Debug.Log(collider.gameObject);
                        canSpawnHere = false;
                        break;
                    }
                }

            }

            if (canSpawnHere)
            {
                spawnPoint = item;
                //Debug.Log("Last tested point: " + item);
                break;
            }
        }



        return canSpawnHere;
    }




   
}
