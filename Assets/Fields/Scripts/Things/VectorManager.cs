using UnityEngine;

public class VectorManager : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 getMousePosition()
    {
        Vector3 MousePosition = Input.mousePosition;
        MousePosition.z = 0;
        return MousePosition;
    }

    public Vector3 getWorldPosition(Vector3 worldPosition)
    {
        worldPosition = mainCamera.ScreenToWorldPoint(getMousePosition());
        worldPosition.z = 0;
        return worldPosition;
    }

    public static Vector3Int ChangeVector3ToVector3Int(Vector3 vector3)
    {
        return new Vector3Int(
            Mathf.RoundToInt(vector3.x),
            Mathf.RoundToInt(vector3.y),
            Mathf.RoundToInt(vector3.z));
    }
}
