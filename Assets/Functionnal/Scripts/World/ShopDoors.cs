using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class ShopDoors : MonoBehaviour
	{
		[Header("References")]
		[Space]
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private Sprite _openSprite;
		[SerializeField] private Sprite _closeSprite;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.GetComponentInParent<TEntity>())
			{
				_spriteRenderer.sprite = _openSprite;
			}
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.gameObject.GetComponentInParent<TEntity>())
			{
				_spriteRenderer.sprite = _closeSprite;
			}
		}
	}
}