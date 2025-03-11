using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamage
{
    public UICondition uICondition;

    Condition HpBar { get { return uICondition.HpBar; } }

    void Update()
    {
        
    }
    public void Heal(float amount)
    {
        HpBar.Add(amount);
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        HpBar.Subtract(damageAmount);
        
    }
}
