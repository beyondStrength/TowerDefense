using System.Linq;
using UnityEngine;

public class Turret : PlacedObject
{
    [SerializeField] float radius;

    public int bullets;

    GameObject selectedEnemy;

    private void Update()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        var enemyCollider = enemies.OrderBy(x => (x.transform.position - transform.position).sqrMagnitude).FirstOrDefault();

        selectedEnemy = enemyCollider != null ? enemyCollider.gameObject : null;
        ShootSelectedEnemy();
    }

    void ShootSelectedEnemy()
    {
        // TODO: check if there is bullets and shoot the enemy
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);

        if (selectedEnemy != null)
        {
            // show selected enemy
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, selectedEnemy.transform.position);
        }
    }
}
