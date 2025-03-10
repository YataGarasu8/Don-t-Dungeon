using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipment : MonoBehaviour
{
    public ItemDate item;
    public Image equipIcon;
    public Image boostIcon;
    public Transform dropPosition;
    public TextMeshProUGUI countText;

    public bool equipped;
    public int count;
    

    private void Start()
    {
        CharacterManager.Instance.Player.addItem += AddItem;
    }
    void AddItem()
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

    }
    void Set()
    {
        if(item.type == ItemType.Equipable)
        {

        }
        else if (item.type == ItemType.Boost)
        {

        }
    }
    public void ThrowTtem(ItemDate date)
    {
        Instantiate(date.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 180));
    }
}
