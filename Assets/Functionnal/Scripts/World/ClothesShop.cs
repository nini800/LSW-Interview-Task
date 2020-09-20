using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class ClothesShop : TInteractable
	{
		[SerializeField] private ClothesShopItem[] _shopItems;

		public ClothesShopItem[] ShopItems => _shopItems;

		public override void StartInteract()
		{
			OpenClothesShopUI();
			base.StartInteract();
		}

		public virtual void OpenClothesShopUI()
		{
			UI_Game.Instance.ClothesShop.OpenShop(this);
		}
	}
}