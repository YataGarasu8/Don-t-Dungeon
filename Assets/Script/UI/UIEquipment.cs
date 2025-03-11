using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipment : MonoBehaviour
{
    private PlayerController playerController;

    public ItemDate item;
    public EquipSlot equipSlot;
    public BoostSlot boostSlot;

    public Transform dropPosition;
    public TextMeshProUGUI countText;

    public float count;
    

    private void Start()
    {
        playerController = CharacterManager.Instance.Player.playerController;
        dropPosition = CharacterManager.Instance.Player.dropPosition;
        CharacterManager.Instance.Player.addItem += AddItem;
    }
    private void Update()
    {
        CountDown();
    }
    void AddItem()
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

    }
    public void Boosted(ItemDate item)
    {
        boostSlot.item = item;
        boostSlot.Set();
        StartCoroutine(RollBackBoost(item));
        boostSlot.Clear();
    }
    void ThrowTtem(ItemDate date)
    {
        Instantiate(date.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
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
    }
}
