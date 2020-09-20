using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InterviewTask
{
	public class UI_ClothesShop : UI_Window
	{
		#region Vars, Fields, Getters
		[Header("Parameters")]
		[Space]
		[SerializeField] private Color _buyTextNothingColor;
		[SerializeField] private Color _buyTextForbiddenColor;
		[SerializeField] private Color _buyTextAuthorizedColor;

		[Header("References")]
		[Space]
		[SerializeField] private TextMeshProUGUI _itemNameText;
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private Button _buyButton;
		[SerializeField] private TextMeshProUGUI _buyText;
		[SerializeField] private Button[] _itemSlots;

		private ClothesShop _openingShop;
		private ClothesShopItem _selectedItem;
		#endregion

		#region Utilities
		public override void Open()
		{
			if (_openingShop == null) { return; }
			base.Open();
		}
		public override void Close()
		{
			if (_openingShop != null) { return; }
			base.Close();
		}

		public void OpenShop(ClothesShop openingShop)
		{
			_openingShop = openingShop;
			Open();

			ResetWindow();
			InitializeWindow();
		}
		public void CloseShop()
		{
			_openingShop?.StopInteract();
			_openingShop = null;
			Close();

			ResetWindow();
		}
		public void BuyAndCloseShop()
		{
			if (_selectedItem != null && TEntity.Player.Money >= _selectedItem.ItemPrice)
			{
				//TODO: Apply Item on Player

				TEntity.Player.AddMoney(-_selectedItem.ItemPrice);
				CloseShop();
			}
			else
			{
				CloseShop();
			}
		}

		private void InitializeWindow()
		{
			//Icons
			for (int i = 0; i < _openingShop.ShopItems.Length; i++)
			{
				((Image)_itemSlots[i].targetGraphic).sprite = _openingShop.ShopItems[i].Icon;
				_itemSlots[i].interactable = true;
			}
		}
		private void ResetWindow()
		{
			//Selected Item
			_selectedItem = null;

			//Icons
			for (int i = 0; i < _itemSlots.Length; i++)
			{
				((Image)_itemSlots[i].targetGraphic).sprite = null;
				_itemSlots[i].interactable = false;
			}

			//Buy Button
			_buyButton.interactable = false;
			//Buy Text
			_buyText.color = _buyTextNothingColor;
			//Price & ItemName texts
			_priceText.text = "";
			_itemNameText.text = "";
		}

		public void UpdateItemInfos(int itemId)
		{
			//Check if we didnt clicked on an invalid button
			if (itemId >= 0 && itemId < _openingShop.ShopItems.Length)
			{
				//update price
				int itemPrice = _openingShop.ShopItems[itemId].ItemPrice;
				_priceText.text = "Price: " + itemPrice + "$";

				//Update item Name
				_itemNameText.text = _openingShop.ShopItems[itemId].ItemName;

				//update buyButton text and interactable
				if (TEntity.Player.Money >= itemPrice)
				{
					_buyText.color = _buyTextAuthorizedColor;
					_buyButton.interactable = true;
				}
				else
				{
					_buyText.color = _buyTextForbiddenColor;
					_buyButton.interactable = false;
				}

				//Store the selected item in case we buy it
				_selectedItem = _openingShop.ShopItems[itemId];
			}
		}
		#endregion
	}
}