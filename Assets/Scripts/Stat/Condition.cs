using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public Image HPBar;

    private void Start()
    {
        curValue = maxValue;
    }

    private void Update()
    {
        HPBar.fillAmount = curValue / maxValue;
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
    }

}

