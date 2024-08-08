using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject InventoryMenu;
    public ItemSlot[] itemSlots;

    public ItemSO[] itemSO;

    private bool MenuActive;

    private void Start()
    {
        InventoryMenu.SetActive(false);
    }

    private void Update()
    {
        CloseOpen(MenuActive);
    }

    public int AddItem(string _itemName, int _quantity, Sprite _sprite, string _itemDescription)
    {
        ItemSO itemData = GetItemSO(_itemName);

        if (itemData == null)
        {
            Debug.LogWarning("ItemSO not found for item: " + _itemName);
            return _quantity;
        }

        // Try to add items to slots that already contain the same item
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].itemName == _itemName && !itemSlots[i].isFull)
            {
                int leftOverItems = itemSlots[i].AddItem(_itemName, _quantity, _sprite, _itemDescription, itemData);
                if (leftOverItems <= 0)
                {
                    return 0;
                }
                _quantity = leftOverItems;
            }
        }

        // Try to add items to empty slots
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (string.IsNullOrEmpty(itemSlots[i].itemName) || itemSlots[i].quantity == 0)
            {
                int leftOverItems = itemSlots[i].AddItem(_itemName, _quantity, _sprite, _itemDescription, itemData);
                if (leftOverItems <= 0)
                {
                    return 0;
                }
                _quantity = leftOverItems;
            }
        }

        return _quantity; // Return remaining quantity if slots are full
    }

    public void RemoveSelect()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].select.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }

    public void CloseOpen(bool menuActive)
    {
        
        MenuActive = menuActive;
        if (Input.GetKeyDown(KeyCode.P) && MenuActive)
        {
            InventoryMenu.SetActive(false);
            MenuActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && !MenuActive)
        {
            InventoryMenu.SetActive(true);
            MenuActive = true;
        }
        if (!MenuActive)
        {
            InventoryMenu.SetActive(false);
            MenuActive = false;
        }
        else
        {
            InventoryMenu.SetActive(true);
            MenuActive = true;
        }
    }

    public bool UseItem(ItemSO itemData)
    {
        if (itemData != null)
        {
            return itemData.UseItem();
        }
        return false;
    }

    private ItemSO GetItemSO(string itemName)
    {
        foreach (ItemSO item in itemSO)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }
        return null;
    }
}