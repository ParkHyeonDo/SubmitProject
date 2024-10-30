using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UIHP uiHP;
    Condition hp { get { return uiHP.hp; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.curValue <= 0f) 
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("쥬금");
    }

    public void Heal(float amount) 
    {
        hp.Add(amount);
        // hp.curValue += amount; 근본적으론 이거지만 함수를 만들어놔서 호출중
    }
}
