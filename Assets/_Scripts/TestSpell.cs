using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestSpell : MonoBehaviour
{
    public GameObject projectile;
    //public int minDamage;
    //public int maxDamage;
    private int damage;
    private int projectileForce;

    void Start()
    {
        damage = StatsHandler.Instance.projectileDamage;
        projectileForce = StatsHandler.Instance.projectileVelocity;
    }

    void Update(){
        if(Input.GetMouseButtonDown(1)){
            GameObject spell = Instantiate(projectile,transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;

            spell.GetComponent<Rigidbody2D>().linearVelocity = direction * projectileForce;
//            spell.GetComponent<TestProjectile>().damage = Random.Range();
        }
    }
}
