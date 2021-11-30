using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager i;

    Camera mainCamera;

    public PlaceableObject selectedObject;

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(selectedObject.prefab, point, Quaternion.identity);
        }
    }
}
