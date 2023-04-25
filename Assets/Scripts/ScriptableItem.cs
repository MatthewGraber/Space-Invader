using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Item")]

public class ScriptableItem : ScriptableObject
{
    public int ID;
    public ItemType itemType;
    public GameItem ItemPrefab;
    // public BaseUnit UnitPrefab;

    private void Awake()
    {
        ItemPrefab.ID = ID;
    }

}

public enum ItemType
{
    Player,
    BasicEnemy,
    CoolEnemy,
    Block,
    Projectile
}