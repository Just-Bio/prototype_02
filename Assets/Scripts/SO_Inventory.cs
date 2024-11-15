using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New inventory", menuName = "InventorySystem/Inventory")]
public class SO_Inventory : ScriptableObject
{
	public List<InventorySlot> container = new List<InventorySlot>();
	public void addItem(SO_Items _item, int _itemCount)
	{
		bool itemFound = false;
		for (int i = 0; i < container.Count; i++)
		{
			if(container[i].item == _item)
			{
				container[i].AddAmount(_itemCount);
				itemFound = true;
				break;
			}
		}
		if (!itemFound)
		{
			container.Add(new InventorySlot(_item, _itemCount));
		}
	}
	public void removeItem(SO_Items _item, int _itemCount)
	{
		for (int i = 0; i < container.Count; i++)
		{
			if (container[i].item == _item)
			{
				container[i].RemoveAmount(_itemCount);
				if (container[i].itemCount <= 0)
				{
					container.Remove(container[i]);
				}
				break;
			}
		}
	}
}
[System.Serializable]
public class InventorySlot
{
	public SO_Items item;
	public int itemCount;
	public InventorySlot(SO_Items _item, int _itemCount)
	{
		item = _item;
		itemCount = _itemCount;
	}
	public void AddAmount(int value)
	{
		itemCount += value;
	}
	public void RemoveAmount(int value)
	{
		itemCount -= value;
	}
}