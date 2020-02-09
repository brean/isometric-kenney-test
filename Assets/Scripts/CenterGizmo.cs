using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * draw a line at the object center (shoule be the pivot center as well)
 */
[ExecuteInEditMode]
public class CenterGizmo : MonoBehaviour
{
    public Color color = Color.magenta;
    
    void OnDrawGizmos()
    {
        Gizmos.color = color;

        Gizmos.DrawLine(
            transform.position + Vector3.left,
            transform.position + Vector3.right
        );
    }
    
}
