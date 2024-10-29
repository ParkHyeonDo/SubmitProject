using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHP : MonoBehaviour
{
    public Condition hp;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Player.condition.uiHP = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
