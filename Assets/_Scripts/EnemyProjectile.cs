using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Colision detection
        if (collision.tag == "Player")
        {
            Debug.Log("Colided with Player");

            StatsHandler.Instance.PlayerTakesDamage(damage);
            Destroy(gameObject);
        }
    }
}
