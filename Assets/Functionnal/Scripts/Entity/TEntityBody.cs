using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace InterviewTask
{
	public class TEntityBody : MonoBehaviour
	{
		[Serializable]
		private class TEntityBodySocketReference
		{
			public TEntityBodySocketReference(TBodySocket socket)
			{
				_socket = socket;
			}

			[SerializeField, ReadOnly] private TBodySocket _socket;
			[SerializeField] private SpriteRenderer _spriteRenderer;

			public TBodySocket Socket => _socket;
			public SpriteRenderer SpriteRenderer => _spriteRenderer;
		}

		[Header("Parameters")]
		[Space]
		[SerializeField] private ClothesShopItem _defaultHat;
		[SerializeField] private ClothesShopItem _defaultShirt;
		[SerializeField] private ClothesShopItem _defaultPants;
		[SerializeField] private ClothesShopItem _defaultShoes;

		[Header("References")]
		[Space]
		[SerializeField] private TEntityBodySocketReference[] _bodySockets;
		[Space]
		[SerializeField] private Animator _animator;

		private ClothesShopItem[] _storedEquippedItems;
		private ClothesShopItem[] _equippedItems;

		private void Awake()
		{
			_equippedItems = new ClothesShopItem[Enum.GetValues(typeof(TClothType)).Length];
			EquipItem(_defaultHat);
			EquipItem(_defaultShirt);
			EquipItem(_defaultPants);
			EquipItem(_defaultShoes);
		}

		public void PlayAnimation(string animationName)
		{
			_animator.CrossFadeInFixedTime(animationName, 0.2f, 0, 0.2f, 0.2f);
		}

		public void StartEquipPreview()
		{
			_storedEquippedItems = new ClothesShopItem[_equippedItems.Length];
			for (int i = 0; i < _equippedItems.Length; i++)
			{
				_storedEquippedItems[i] = _equippedItems[i];
			}
		}
		public void StopEquipPreview()
		{
			for (int i = 0; i < _storedEquippedItems.Length; i++)
			{
				if (_storedEquippedItems[i] != null)
				{
					EquipItem(_storedEquippedItems[i]);
				}
				else if (_equippedItems[i] != null)
				{
					for (int j = 0; j < _equippedItems[i].ItemModelParams.Length; j++)
					{
						int socketIndex = (int)_equippedItems[i].ItemModelParams[j].Socket;
						_bodySockets[socketIndex].SpriteRenderer.sprite = null;
					}
					_equippedItems[i] = null;
				}
			}
		}

		public void EquipItem(ClothesShopItem item)
		{
			if (item == null) { return; }

			int itemIndex = (int)item.ClothType;
			_equippedItems[itemIndex] = item;

			for (int i = 0; i < item.ItemModelParams.Length; i++)
			{
				int socketIndex = (int)item.ItemModelParams[i].Socket;
				_bodySockets[socketIndex].SpriteRenderer.sprite = item.ItemModelParams[i].Sprite;
			}

			//Check if we must hide hairs
			for (int i = 0; i < _equippedItems.Length; i++)
			{
				if (_equippedItems[i] == null) { continue; }
				if (_equippedItems[i].HideHairs == true)
				{
					_bodySockets[(int)TBodySocket.Hairs].SpriteRenderer.enabled = false;
					return;
				}
			}
			_bodySockets[(int)TBodySocket.Hairs].SpriteRenderer.enabled = true;
		}

		#region Editor
		private void OnValidate()
		{
			int bodysocketCount = Enum.GetValues(typeof(TBodySocket)).Length;
			if (_bodySockets.Length < bodysocketCount)
			{
				Array.Resize(ref _bodySockets, bodysocketCount);
			}

			for (int i = 0; i < _bodySockets.Length; i++)
			{
				TBodySocket socket = (TBodySocket)i;
				if (_bodySockets[i] == null || _bodySockets[i].Socket != socket)
				{
					_bodySockets[i] = new TEntityBodySocketReference(socket);
				}
			}
		}
		#endregion
	}
}