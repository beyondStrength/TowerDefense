using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager i;

    [SerializeField] NavMeshSurface2d navMesh;

    Camera mainCamera;

    [SerializeField] TMP_Text selectedObjectText;

    [SerializeField] PlaceableObject[] placeableObjects;
    PlaceableObject selectedObject;
    int selectedObjectIndex = 0;

    private void Awake()
    {
        i = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;

        selectedObject = placeableObjects[selectedObjectIndex];
        selectedObjectText.text = selectedObject.name;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Instantiate(selectedObject.prefab, point, Quaternion.identity);
            navMesh.BuildNavMesh();
        }

        if(Input.mouseScrollDelta == Vector2.up)
        {
            selectedObjectIndex--;

            if (selectedObjectIndex <= 0)
                selectedObjectIndex = 0;

            selectedObject = placeableObjects[selectedObjectIndex];
            selectedObjectText.text = selectedObject.name;
        }
        else if(Input.mouseScrollDelta == Vector2.down)
        {
            selectedObjectIndex++;

            if (selectedObjectIndex >= placeableObjects.Length - 1)
                selectedObjectIndex = placeableObjects.Length - 1;

            selectedObject = placeableObjects[selectedObjectIndex];
            selectedObjectText.text = selectedObject.name;
        }
    }
}
