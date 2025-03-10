using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Equipable, Boost
}
[CreateAssetMenu(fileName ="ItemDate",menuName = "ItemDate")]//스크립터블 오브젝트를 Project창에서 만들 수 있게 해준다.
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
