using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float starValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;

    void Start()
    {
        curValue = starValue;
    }
    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }
    float GetPercentage()
    {
        return curValue / maxValue;
    }
    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);//�������� ���� �ּҰ�, curValue + value�� maxValue �߿� ���� ���� curValue�� �־� curValue�� maxValue�� �Ѵ� ���� �����Ѵ�.
    }
    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);//���� ���� �ִ�, curValue + value�� maxValue �߿� ū ���� curValue�� �־� curValue�� ������ �Ǵ� ���� �����Ѵ�.
    }
}
