using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string ItemDescription;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private int maxNumberOfItems;

    public GameObject select;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    public Image ImageTitle;
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    // New variable to store ItemSO
    public ItemSO itemData;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
    }

    public int AddItem(string _itemName, int _quantity, Sprite _sprite, string _itemDescription, ItemSO _itemData)
    {
        if (isFull && !string.IsNullOrEmpty(itemName) && itemName != _itemName)
        {
            return _quantity;
        }

        // Assign item data
        this.itemData = _itemData;

        // NAME
        this.itemName = _itemName;
        // IMAGE
        this.itemSprite = _sprite;
        ImageTitle.sprite = _sprite;
        itemImage.sprite = _sprite;
        itemImage.enabled = true;
        // DESCRIPTION
        this.ItemDescription = _itemDescription;
        DescriptionText.enabled = true;
        TitleText.enabled = true;

        // QUANTITY
        int totalQuantity = this.quantity + _quantity;
        if (totalQuantity > maxNumberOfItems)
        {
            int extraItems = totalQuantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            isFull = true;
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
            return extraItems;
        }
        else
        {
            this.quantity = totalQuantity;
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
            isFull = this.quantity >= maxNumberOfItems;
            return 0;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLiftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLiftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemData);
            if (usable)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                    EmptySlot();
            }
        }
        else
        {
            inventoryManager.RemoveSelect();
            select.SetActive(true);
            thisItemSelected = true;
            TitleText.text = itemName;
            DescriptionText.text = ItemDescription;
            itemImage.sprite = itemSprite;
            ImageTitle.sprite = itemSprite;
        }
    }

    public void OnRightClick()
    {
        
        //Create a new Item
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = ItemDescription;
        
        
        //Create and modify the SR
        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingOrder = 5;
        sr.sortingLayerName = "Ground";

        //Add a collider
        itemToDrop.AddComponent<BoxCollider2D>();

        //Set the location
        itemToDrop.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(1f,0,0);
        //itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(.5f, 0, 0);
        itemToDrop.transform.localScale = new Vector3(.5f, .5f, .5f);

        //Subtract the item
        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
            EmptySlot();
    }
    

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.enabled = false;

        TitleText.text = "";
        DescriptionText.text = "";
        ImageTitle.enabled = false;
    }
}