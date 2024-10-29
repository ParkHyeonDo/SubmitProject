using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class ItemObject : MonoBehaviour
{
    public ItemData data;

    public string InteractPrompt() 
    {
        string str = $"{data.displayName}\n{data.description} ";
        return str ;
    }
}

