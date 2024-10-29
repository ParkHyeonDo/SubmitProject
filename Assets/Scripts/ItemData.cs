using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName="New Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string description;
    public GameObject dropPrefab;
}