using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "ClothesShopItem", menuName = "Entity/ClothesShopItem", order = 100)]
	public class ClothesShopItem : ScriptableObject
	{
		[Serializable]
		public class ItemModelParameters
		{
			[SerializeField] private TBodySocket _socket;
			[SerializeField] private Sprite _sprite;

			public TBodySocket Socket => _socket;
			public Sprite Sprite => _sprite;
		}

		[Header("Parameters")]
		[Space]
		[SerializeField] private TClothType _clothType;
		[SerializeField] private string _itemName;
		[SerializeField] private Sprite _icon;
		[SerializeField] private ItemModelParameters[] _itemModelParams;
		[SerializeField] private bool _hideHairs = false;
		[SerializeField] private int _itemPrice;

		public TClothType ClothType => _clothType;
		public string ItemName => _itemName;
		public Sprite Icon => _icon;
		public ItemModelParameters[] ItemModelParams => _itemModelParams;
		public bool HideHairs => _hideHairs;
		public int ItemPrice => _itemPrice;
	}
}