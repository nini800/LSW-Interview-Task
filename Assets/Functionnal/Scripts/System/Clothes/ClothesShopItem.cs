using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "ClothesShopItem", menuName = "Entity/ClothesShopItem", order = 100)]
	public class ClothesShopItem : ScriptableObject
	{
		[Header("Parameters")]
		[Space]
		[SerializeField] private TBodySocket _itemSocket;
		[SerializeField] private string _itemName;
		[SerializeField] private Sprite _icon;
		[SerializeField] private GameObject _itemModel;
		[SerializeField] private int _itemPrice;

		public TBodySocket ItemSocket => _itemSocket;
		public string ItemName => _itemName;
		public Sprite Icon => _icon;
		public GameObject ItemModel => _itemModel;
		public int ItemPrice => _itemPrice;
	}
}