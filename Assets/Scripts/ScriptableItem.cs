using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Item")]

public class ScriptableItem : ScriptableObject
{
    public ItemType itemType;
    public GameItem ItemPrefab;
    // public BaseUnit UnitPrefab;
    
}

public enum ItemType
{
    Player,
    BasicEnemy,
    CoolEnemy,
    Block,
    Projectile
}