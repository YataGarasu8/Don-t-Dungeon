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
        curValue = Mathf.Min(curValue + value, maxValue);//더해졌을 때의 최소값, curValue + value와 maxValue 중에 작은 값을 curValue에 넣어 curValue가 maxValue를 넘는 것을 방지한다.
    }
    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);//뺐을 때의 최댓값, curValue + value와 maxValue 중에 큰 값을 curValue에 넣어 curValue가 음수가 되는 것을 방지한다.
    }
}
