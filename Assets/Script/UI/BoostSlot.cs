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
    public void Set()
    {
        boostMark.gameObject.SetActive(true);
        boostIcon.sprite = item.icon;
        CharacterManager.Instance.Player.playerController.BoostJumpForce(item.addJumpForce);
    }
    public void Clear()
    {
        CharacterManager.Instance.Player.playerController.RollBackJumpForce(item.addJumpForce);
        boostMark.gameObject.SetActive(false);
    }
}
