using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
	private Camera mainCam;
	public SO_Inventory playerInventory;
	public GameObject inventoryUI;
	public Transform inventoryContent;
	public GameObject inventoryPrefab;
	public FirstPersonController firstPersonController;
	public Transform objectHolder;
	public float InteractionDistance;
	public bool inventoryDisplayed;
	private void Awake() { mainCam = Camera.main; inventoryDisplayed = false; DisplayInventoryUI(); }
	// Update is called once per frame
	void Update()
	{
		CheckRaycast();
		if (Input.GetKeyDown(KeyCode.I)) { ToggleDisplay(); if (inventoryDisplayed == true) { DisplayInventoryUI(); } }		
	}

	private void CheckRaycast()
	{
		var ray = mainCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out var hit, InteractionDistance))
		{
			if (Input.GetMouseButtonDown(0))
			{

				if (hit.collider.TryGetComponent(out keypadButton keypadButtonHit))
				{
					keypadButtonHit.PressButton();
				}
			}
			if (hit.transform.CompareTag("Interactable")) // Checks the object has an "InteractableObject" tag
			{
				if (hit.collider.TryGetComponent(out Outline outline))
				{
					outline.enabled = true;
					objectHolder = hit.collider.transform;
				}
				if (Input.GetKeyDown(KeyCode.E))
				{
					if (hit.collider.TryGetComponent(out ItemManager itemManager))
					{
						playerInventory.addItem(itemManager.itemID, 1);
						Destroy(hit.transform.gameObject);
					}
				}
			}
		}
		else
		{
			if (objectHolder != null)
			{
				if (objectHolder.TryGetComponent(out Outline outline))
				{
					outline.enabled = false;
				}
				objectHolder = null;
			}

		}

	}
	private void ToggleDisplay()
	{
		inventoryDisplayed = !inventoryDisplayed;
		inventoryUI.SetActive(inventoryDisplayed);
		Cursor.lockState = inventoryDisplayed ? CursorLockMode.None : CursorLockMode.Locked;
		playerPause(!inventoryDisplayed);
	}
	private void playerPause(bool causeofPause)
	{
		firstPersonController.cameraCanMove = firstPersonController.playerCanMove = firstPersonController.enableHeadBob = causeofPause;
	}
	private void DisplayInventoryUI()
	{
		foreach (Transform item in inventoryContent)
		{
			Destroy(item.gameObject);
		}
		foreach (InventorySlot item in playerInventory.container)
		{
			GameObject itemInInv = Instantiate(inventoryPrefab, inventoryContent);
			var itemName = itemInInv.transform.Find("itemName").GetComponent<Text>();
			var itemNumber = itemInInv.transform.Find("itemNumber").GetComponent<Text>();
			if (itemName != null) { itemName.text = item.item.itemName; }
			itemNumber.text = item.itemCount.ToString();
		}
	}
	private void OnApplicationQuit()
	{
		playerInventory.container.Clear();
	}
}
