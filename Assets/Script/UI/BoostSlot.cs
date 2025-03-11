using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoostSlot : MonoBehaviour
{
    public ItemDate item;
    public Image boostIcon;
    public TextMeshProUGUI countText;
    public GameObject boostMark;

    private void Start()
    {
        boostMark.gameObject.SetActive(false);
    }
    void Set(ItemDate date)
    {
        boostMark.gameObject.SetActive(true);
        boostIcon.sprite = date.icon;
        CharacterManager.Instance.Player.playerController.BoostJumpForce(item.addJumpForce);
    }
    void Clear()
    {
        CharacterManager.Instance.Player.playerController.RollBackJumpForce(item.addJumpForce);
        boostMark.gameObject.SetActive(false);
    }
}
