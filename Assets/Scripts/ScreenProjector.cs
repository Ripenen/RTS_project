using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ScreenProjector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public Vector2 WorldToScreenPoint(Vector3 point) => _camera.WorldToScreenPoint(point);

    public Rect WorldBoundsToScreenRect(Bounds worldBounds)
    {
        Vector3 center = worldBounds.center;
        Vector3 extents = worldBounds.extents;
        
        Vector3[] worldCorners = 
        {
            new Vector3( center.x + extents.x, center.y + extents.y, center.z + extents.z ),
            new Vector3( center.x + extents.x, center.y + extents.y, center.z - extents.z ),
            new Vector3( center.x + extents.x, center.y - extents.y, center.z + extents.z ),
            new Vector3( center.x + extents.x, center.y - extents.y, center.z - extents.z ),
            new Vector3( center.x - extents.x, center.y + extents.y, center.z + extents.z ),
            new Vector3( center.x - extents.x, center.y + extents.y, center.z - extents.z ),
            new Vector3( center.x - extents.x, center.y - extents.y, center.z + extents.z ),
            new Vector3( center.x - extents.x, center.y - extents.y, center.z - extents.z ),
        };
        
        Vector2[] screenCorners = new Vector2[8];

        for (int i = 0; i < worldCorners.Length; i++)
            screenCorners[i] = WorldToScreenPoint(worldCorners[i]);

        Vector2 position = screenCorners[0];
        Vector2 oppositePoint = screenCorners[0];
        
        foreach (var screenCorner in screenCorners)
        {
            position.x = Mathf.Min(screenCorner.x, position.x);
            position.y = Mathf.Max(screenCorner.y, position.y);

            oppositePoint.x = Mathf.Max(screenCorner.x, oppositePoint.x);
            oppositePoint.y = Mathf.Min(screenCorner.y, oppositePoint.y);
        }

        return Rect.MinMaxRect(position.x, position.y,
            oppositePoint.x, oppositePoint.y);
    }
}