using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityVisual", menuName = "Entity/Components/Visual", order = 100)]
	public class TEntityVisualComponent : TEntityComponentBase
	{
		[Header("Parameters")]
		[Space]
		[SerializeField] private float _directionArrowDistance = 1f;

		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityVisual(this, master);
		}

		public class TEntityVisual : TEntityComponent
		{
			#region Construction
			public TEntityVisual(TEntityVisualComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityVisualComponent _data;
			public new TEntityVisualComponent Data => _data;
			#endregion

			#region Behaviour
			public override void OnAwake()
			{
				HandleDisplayEntityName();
			}
			private void HandleDisplayEntityName()
			{
				if (References.NameDisplay != null)
				{
					References.NameDisplay.text = Master.EntityName;
				}
			}

			public override void OnUpdate()
			{
				HandleRotateDirectionArrow();
			}
			private void HandleRotateDirectionArrow()
			{
				if (References.DirectionArrow == null) { return; }

				References.DirectionArrow.transform.rotation = Quaternion.Euler(0f, 0f, Interactions.CurrentInteractionAngle - 90f);

				float currentAngleRad = Interactions.CurrentInteractionAngle * Mathf.Deg2Rad;
				References.DirectionArrow.transform.localPosition = new Vector2(Mathf.Cos(currentAngleRad), Mathf.Sin(currentAngleRad)) * _data._directionArrowDistance;
			}
			#endregion

			#region Events
			public override void OnEnable()
			{
				Interactions.OnSelectInteractable += OnSelectInteractable;
				Interactions.OnDeselectInteractable += OnDeselectInteractable;
			}
			public override void OnDisable()
			{
				Interactions.OnSelectInteractable -= OnSelectInteractable;
				Interactions.OnDeselectInteractable -= OnDeselectInteractable;
			}

			private const string SELECTION_DISPLAYER_NAME = "SelectionDisplay";
			private void OnSelectInteractable(TEntity master, ITInteractable interactable)
			{
				interactable.Widget.SetActive(true);

				//I would never have not done that on a true project.
				for (int i = 0; i < interactable.SpriteRenderers.Length; i++)
				{
					GameObject selectionDisplay = new GameObject(SELECTION_DISPLAYER_NAME);
					selectionDisplay.transform.SetParent(interactable.SpriteRenderers[i].transform);
					selectionDisplay.transform.localPosition = default;
					selectionDisplay.transform.localRotation = default;
					selectionDisplay.transform.localScale = Vector3.one * 1.05f;
					SpriteRenderer rend = selectionDisplay.AddComponent<SpriteRenderer>();
					rend.sprite = interactable.SpriteRenderers[i].sprite;
					rend.color = Color.black;
					TSpriteOrderer orderer = selectionDisplay.AddComponent<TSpriteOrderer>();
					orderer.SetOrderInLayerForcedOffset(-1);
				}
			}
			private void OnDeselectInteractable(TEntity master, ITInteractable interactable)
			{
				interactable.Widget.SetActive(false);

				//I would have not done that on a true project.
				for (int i = 0; i < interactable.SpriteRenderers.Length; i++)
				{
					Transform t = interactable.SpriteRenderers[i].transform.Find(SELECTION_DISPLAYER_NAME);
					if (t != null)
					{
						Destroy(t.gameObject);
					}
				}
			}
			#endregion
		}
	}
}