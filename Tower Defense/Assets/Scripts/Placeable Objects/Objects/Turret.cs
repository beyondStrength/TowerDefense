using System.Linq;
using UnityEngine;

public class Turret : PlacedObject
{
    public int health = 100;

    [SerializeField] float radius;
    [SerializeField] int damage;

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
        if(bullets > 0)
        {
            Enemy enemy = selectedEnemy.GetComponent<Enemy>();

            enemy.health -= damage;
        }
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
