using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            KeynDoorHandler.Instance.PickUpKey();
            Destroy(gameObject);
        }
    }
}
