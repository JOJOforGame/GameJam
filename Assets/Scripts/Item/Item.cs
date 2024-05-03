using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    public string id;
    public string name;
    public Sprite sp;
    public Sprite icon;
}

public enum ItemType
{
    Item,
    Puzzle,
}