using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition HpBar;

    private void Start()
    {
        CharacterManager.Instance.Player.playerCondition.uICondition = this;
    }
}
