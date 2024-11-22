using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object Encountered" + collision.tag);
        if(collision.tag == "Player")
        {
            StatsHandler.Instance.AddCoin();
            Destroy(gameObject);
        }
    }
}
