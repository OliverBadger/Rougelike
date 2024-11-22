using UnityEngine;

public class KeynDoorHandler : MonoBehaviour
{
    public static KeynDoorHandler Instance;
    public bool isCollected;
    public int keyTotalRequirements;
    public GameObject door;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        isCollected = false;
    }

    public void PickUpKey()
    {
        isCollected = true;
        door.SetActive(false);
    }
}
