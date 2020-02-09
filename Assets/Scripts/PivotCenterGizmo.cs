using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PivotCenterGizmo : MonoBehaviour
{
    public int pixelToCoords = 1024;
    public Sprite sprite;
    // Start is called before the first frame update

    void Awake() {
        OnValidate();
    }

    void OnValidate() {
        GetSprite();
    }
    bool GetSprite()
    {
        if (!sprite) {
            sprite = GetComponent<SpriteRenderer>().sprite;
        }
        return (bool)(sprite != null);
    }

    // Update is called once per frame
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        //Debug.Log("Pivot " + sprite.pivot);
        //Debug.Log("Rect " + sprite.rect);

        Gizmos.DrawLine(
            transform.position + Vector3.left,
            transform.position + Vector3.right
        );
    }
    
}
