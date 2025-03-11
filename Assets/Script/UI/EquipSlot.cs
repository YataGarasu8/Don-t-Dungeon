using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{
    public ItemDate item;
    public Image equipIcon;

    // Start is called before the first frame update
    void Set(ItemDate date)
    {
        equipIcon.sprite = item.icon;
        equipIcon.gameObject.SetActive(true);
        CharacterManager.Instance.Player.playerController.BoostJumpForce(item.addJumpForce);
    }
    void Clear()
    {
        if (equipIcon != null)
        {
            item = null;
            equipIcon.gameObject.SetActive(false);
            CharacterManager.Instance.Player.playerController.RollBackJumpForce(item.addJumpForce);
        }
    }
}
