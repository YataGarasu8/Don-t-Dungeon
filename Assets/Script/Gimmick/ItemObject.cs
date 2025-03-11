using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}
public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemDate itemDate;

    public string GetInteractPrompt()
    {
        string prompt = $"{itemDate.itemName}\n{itemDate.ItemExplanation}";
        return prompt;
    }

    public void OnInteract()
    {
        if (itemDate.type == ItemType.Equipable)
        {
            CharacterManager.Instance.Player.itemDate = itemDate;
            CharacterManager.Instance.Player.addItem?.Invoke();
        }
        else if (itemDate.type == ItemType.Boost)
        {
            //CharacterManager.Instance.Player.uIEquipment.Boosted(itemDate);//결국 어떤 문제일까...
        }
        Destroy(gameObject);
    }
}
