using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController controller;
    public PlayerCondition condition;
    

    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
        condition = GetComponent<PlayerCondition>();
        GameManager.Instance.Player = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
