using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDate",menuName = "ItemDate")]//��ũ���ͺ� ������Ʈ�� Projectâ���� ���� �� �ְ� ���ش�.
public class ItemDate : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string ItemExplanation;
    public float addmoveSpeed;
    public float addmovejumpForce;

}
