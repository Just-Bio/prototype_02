using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Scriptable Item", menuName = "InventorySystem/Items")]

public class SO_Items : ScriptableObject
{
	public GameObject prefab;
	public string itemName;
	public string description;
	public int itemID;
}
