using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    public void Open()
    {
        isOpen = true;
        this.gameObject.SetActive(false);
    }
}
