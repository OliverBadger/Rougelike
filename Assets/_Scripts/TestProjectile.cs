using UnityEngine;

public class TestProjectile : MonoBehaviour
{

    public int damage;

    private void OnTriggerEnter2D(Collider2D collision) {
        //Colision detection
        if(collision.tag == "Enemy"){
            Debug.Log("Colided with Enemy");

            collision.GetComponent<Enemy>().DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
