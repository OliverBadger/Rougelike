using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public int damage;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Colision detection
        if(collision.tag == "Enemy"){
            Debug.Log("Colided with Enemy");

            collision.GetComponent<Enemy>().DealDamage(damage);
            Destroy(gameObject);
        }
        else if(collision.tag == "Player")
        {
            Debug.Log("Colided with Enemy");

            StatsHandler.Instance.PlayerTakesDamage(damage);
            Destroy(gameObject);
        }
    }
}
