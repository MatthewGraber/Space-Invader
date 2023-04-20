using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Item")]

public class ScriptableItem : ScriptableObject
{
    public ItemType unitType;
    public GameItem ItemPrefab;
    // public BaseUnit UnitPrefab;
    
}

public enum ItemType
{
    Player,
    Enemy,
    Block,
    Projectile
}