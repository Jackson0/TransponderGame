using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
   public static List<Vector3> plotPoint = new List<Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointToPlot(Vector3 location)
    {
        plotPoint.Add(location);
    }

    private void OnDrawGizmos()
    {
        foreach (var item in plotPoint)
        {
            Gizmos.DrawWireSphere(item, 0.2f);
        }
    }
}
