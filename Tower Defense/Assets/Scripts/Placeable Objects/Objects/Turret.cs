using System.Linq;
using UnityEngine;

public class Turret : PlacedObject
{
    public int health = 100;

    [Header("Shooting")]

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float radius;
    [SerializeField] int damage;
    public int bullets;

    [SerializeField] float shootRate;
    float shootTimer = 0f;

    Enemy selectedEnemy;

    private void Update()
    {
        shootTimer += Time.deltaTime;
        selectedEnemy = null;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, radius);
        var enemiesSorted = enemies.OrderBy(x => (x.transform.position - transform.position).sqrMagnitude);
        
        foreach (var enemy in enemiesSorted)
        {
            if (enemy.CompareTag("Enemy"))
            {
                selectedEnemy = enemy.GetComponent<Enemy>();
                break;
            }
        }

        ShootSelectedEnemy();

        if (health < 1)
            Die();
    }

    void ShootSelectedEnemy()
    {
        if(selectedEnemy != null && shootTimer >= shootRate && bullets > 0)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.LookAt(selectedEnemy.transform);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward.normalized * 100);

            Quaternion rotation = bullet.transform.rotation;
            rotation.y = 0;
            bullet.transform.rotation = rotation;

            selectedEnemy.health -= damage;
            bullets--;

            shootTimer = 0f;
        }
    }

    void Die()
    {
        Destroy(gameObject);
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
