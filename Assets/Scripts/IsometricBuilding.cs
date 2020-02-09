using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class IsometricBuilding : MonoBehaviour
{
    private float floorHeight;
    private float spriteLowBound = 0.0f;
    private float spriteHalfWidth = 0.0f;

    [SerializeField] private Vector2Int positionInTileMap;

    private Tilemap tileMap;

    private Sprite buildingSprite;

    void Awake() {
        OnValidate();
    }

    void OnValidate() {
        SetTileMap();
        SetBuilding();
    }

    bool SetTileMap() {
        if (tileMap != null) {
            return true;
        }
        GameObject grid = GameObject.Find("Grid - With Script");
        if (!grid) {
            return false;
        }
        
        foreach(Transform child in grid.transform)
        {
            Tilemap tm = child.gameObject.GetComponent<Tilemap>();
            if (tm != null && child.name == "Ground") {
                tileMap = tm;
                return true;
            }
        }
        return false;
    }

    bool SetBuilding() {
        Vector3Int v3TilePosition = new Vector3Int(positionInTileMap.x, positionInTileMap.y, 0);
        buildingSprite = tileMap.GetSprite(v3TilePosition);
        return (bool) (buildingSprite != null);
    }

    void OnDrawGizmos()
    {
        if (!SetTileMap() || !SetBuilding()) {
            return;
        }
        Vector3Int v3TilePosition = new Vector3Int(positionInTileMap.x, positionInTileMap.y, 0);
        Vector3 tileCenter = tileMap.GetCellCenterWorld(v3TilePosition);

        Vector3 floorPos = new Vector3(
            tileCenter.x,
            tileCenter.y,
            tileCenter.z
        );
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(
            floorPos + Vector3.left * buildingSprite.bounds.size.x / 2,
            floorPos + Vector3.right * buildingSprite.bounds.size.x / 2);
    }
}
