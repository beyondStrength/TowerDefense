using UnityEngine;

[CreateAssetMenu(fileName = "New Placeable Object", menuName = "Game/Placeable Object")]
public class PlaceableObject : ScriptableObject
{
    public new string name;
    public GameObject prefab;
}
