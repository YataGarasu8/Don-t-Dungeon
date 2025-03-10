using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Equipable, Boost
}
[CreateAssetMenu(fileName ="ItemDate",menuName = "ItemDate")]//��ũ���ͺ� ������Ʈ�� Projectâ���� ���� �� �ְ� ���ش�.
public class ItemDate : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string ItemExplanation;
    public ItemType type;
    public float addMoveSpeed;
    public float addJumpForce;
    public float activeTime;
    public Sprite icon;
    public GameObject dropPrefab;

}
