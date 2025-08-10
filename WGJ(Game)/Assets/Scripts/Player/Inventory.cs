using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Canvas inventoryCanvas; // Canvas del inventario
    private bool isOpen = false;    // Estado del inventario

    void Start()
    {
        if (inventoryCanvas != null)
            inventoryCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            inventoryCanvas.gameObject.SetActive(isOpen);
        }
    }
}
