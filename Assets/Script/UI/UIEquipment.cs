using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipment : MonoBehaviour
{
    private PlayerController playerController;

    public ItemDate item;
    public Image equipIcon;
    public Image boostIcon;
    public Transform dropPosition;
    public TextMeshProUGUI countText;
    public GameObject boostMark;

    public bool equipped;
    public float count;
    

    private void Start()
    {
        playerController = CharacterManager.Instance.Player.playerController;
        dropPosition = CharacterManager.Instance.Player.dropPosition;
        CharacterManager.Instance.Player.addItem += AddItem;

        boostMark.gameObject.SetActive(false);
    }
    private void Update()
    {
        CountDown();
    }
    void AddItem()
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

    }
    public void ItemGet(ItemDate date)
    {
        if (date == null)
        {
            Debug.LogError("date를 받아오지 못했습니다.");
            return;
        }
        else
        {
            Clear();
            Set(date);
        }
    }
    void Set(ItemDate date)
    {
        if(date.type == ItemType.Equipable)
        {
            equipIcon.sprite = date.icon;
            playerController.BoostJumpForce(date.addJumpForce);
        }
        else if (date.type == ItemType.Boost)
        {
            boostMark.gameObject.SetActive(true);
            boostIcon.sprite = date.icon;
            count = date.activeTime;
            playerController.BoostJumpForce(date.addJumpForce);
            StartCoroutine(RollBackBoost(date));
        }
    }
    void Clear()
    {
        if(item != null)
        {
            ThrowTtem(item);
            playerController.RollBackJumpForce(item.addJumpForce);
            equipIcon.sprite = null;
        }
    }
    void ThrowTtem(ItemDate date)
    {
        Instantiate(date.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 180));
    }
    void CountDown()
    {
        if(count > 0)
        {
            count -= Time.deltaTime;
        }
        countText.text = count.ToString("N0");
    }
    IEnumerator RollBackBoost(ItemDate date)
    {
        yield return new WaitForSeconds(date.activeTime);
        playerController.RollBackJumpForce(date.addJumpForce);
        boostMark.gameObject.SetActive(false);
    }
}
