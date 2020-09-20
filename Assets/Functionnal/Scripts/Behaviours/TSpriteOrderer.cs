using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace InterviewTask
{
	//If I was coding a true game, and not a game-jam like game, it would require to do a 
	//well designed manager in order to optimize this script's task.
	public class TSpriteOrderer : MonoBehaviour
	{
		#region Vars, Fields
		[Header("Parameters")]
		[Space]
		[SerializeField] private float _yPivotOffset = 0f;
		[SerializeField] private int _orderInLayerForcedOffset = 0;
		[Space]
		[SerializeField] private bool _shouldFadeWhenPlayerAbove = false;
		[SerializeField] private Vector2 _fadeRange = new Vector2(0.05f, 1f);
		[SerializeField, Min(0.0001f)] private float _fadeSpeed = 1f;
		[SerializeField, Range(0f, 1f)] private float _fadeTargetAlpha = 0.2f;

		[Header("References")]
		[Space]
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private SortingGroup _sortingGroup;

		private float _originalAlpha = 1f;
		#endregion

		#region Behaviour
		private void Awake()
		{
			if (_spriteRenderer == null) { _spriteRenderer = GetComponent<SpriteRenderer>(); }
			if (_spriteRenderer == null) { return; }
			_originalAlpha = _spriteRenderer.color.a;
		}
		private void Update()
		{
			UpdateOrder();
		}
		private void UpdateOrder()
		{
			if (TCamera.Instance == null)
			{
				UpdateOrder(default);
			}
			else
			{
				UpdateOrder(TCamera.Instance.transform.position.ToV2());
				if (_shouldFadeWhenPlayerAbove == true)
				{
					UpdateFade();
				}
			}
		}
		private void UpdateOrder(Vector2 camPos)
		{
			float yDiff = camPos.y - transform.position.y - _yPivotOffset;
			yDiff *= 100f;//So one unity unit will be one orderInLayer
			if (_spriteRenderer != null)
			{
				_spriteRenderer.sortingOrder = (int)yDiff + _orderInLayerForcedOffset;
			}
			else if (_sortingGroup != null)
			{
				_sortingGroup.sortingOrder = (int)yDiff + _orderInLayerForcedOffset;
			}
		}
		private void UpdateFade()
		{
			Color target;

			//Do not fade out of X bound
			if (TEntity.Player.Position.x <= _spriteRenderer.bounds.min.x ||
				TEntity.Player.Position.x >= _spriteRenderer.bounds.max.x)
			{
				target = _spriteRenderer.color.SetA(_originalAlpha);
			}
			//Fade if inside of X bound and Y bound
			else
			{
				float yDistance = TEntity.Player.Position.y - transform.position.y - _yPivotOffset;
				if (yDistance < _fadeRange.x || yDistance >= _fadeRange.y)
				{
					target = _spriteRenderer.color.SetA(_originalAlpha);

				}
				else
				{
					target = _spriteRenderer.color.SetA(_fadeTargetAlpha);
				}


			}
			_spriteRenderer.color = _spriteRenderer.color.MoveTowards(
				target,
				_fadeSpeed * Time.deltaTime);
		}
		#endregion

		#region Utilities
		public void SetOrderInLayerForcedOffset(int offset)
		{
			_orderInLayerForcedOffset = offset;
		}
		#endregion

		#region Editor
		private void OnValidate()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}
		private void OnDrawGizmosSelected()
		{
			//Display the Y Pivot line
			float lineWidth = 2f;
			Renderer rend = GetComponent<Renderer>();
			if (rend != null)
			{
				lineWidth = rend.bounds.extents.x;
			}
			Gizmos.color = Color.red;
			float minX = transform.position.x - (lineWidth * 0.5f);
			float maxX = transform.position.x + (lineWidth * 0.5f);
			Gizmos.DrawLine(
				new Vector2(minX, transform.position.y + _yPivotOffset),
				new Vector2(maxX, transform.position.y + _yPivotOffset));
		}

#if UNITY_EDITOR
		[CustomEditor(typeof(TSpriteOrderer)), CanEditMultipleObjects]
		public class TSpriteOrdererEditor : Editor
		{
			public override void OnInspectorGUI()
			{
				base.OnInspectorGUI();
				GUILayout.Space(10f);
				if (GUILayout.Button("Update"))
				{
					for (int i = 0; i < targets.Length; i++)
					{
						TSpriteOrderer orderer = (TSpriteOrderer)targets[i];
						orderer.UpdateOrder();
					}
				}
			}
		}
		#endif
		#endregion
	}


}