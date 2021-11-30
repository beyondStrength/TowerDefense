using UnityEngine;

public class Turret : PlacedObject
{
    [SerializeField] float radius;

    public int bullets;

    private void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);

        // TODO: sort the array to closest enemy
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
