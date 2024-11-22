using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    //public int minDamage;
    //public int maxDamage;
    private int damage;
    private int projectileForce;
    //public GameObject origin;

    void Start()
    {
        damage = StatsHandler.Instance.projectileDamage;
        projectileForce = StatsHandler.Instance.projectileVelocity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Shoot(mousePos, myPos);
        }
    }
    public void Shoot(Vector2 target, Vector2 origin)
    {
        Vector2 direction = (target - origin).normalized;
        GameObject shoot = Instantiate(projectile, transform.position, Quaternion.identity);
        shoot.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileForce;
    }
}
