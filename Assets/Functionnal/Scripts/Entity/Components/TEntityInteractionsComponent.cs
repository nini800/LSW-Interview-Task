using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityInteractions", menuName = "Entity/Components/Interactions", order = 100)]
	public class TEntityInteractionsComponent : TEntityComponentBase
	{
		#region Fields, Getters
		[Header("Parameters")]
		[Space]
		[SerializeField] private LayerMask _whatIsInteractable;
		[SerializeField, Min(0f)] private float _interactionDistance = 1f;
		[SerializeField, Min(0f)] private float _interactionDirectionRotateSmoothTime = 0.05f;
		[SerializeField, Min(0f)] private float _interactionAngle = 1f;
		#endregion

		#region Component Building
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityInteractions(this, master);
		}
		#endregion

		public class TEntityInteractions : TEntityComponent
		{
			#region Construction
			public TEntityInteractions(TEntityInteractionsComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityInteractionsComponent _data;
			public new TEntityInteractionsComponent Data => _data;

			private float _currentInteractionAngle = 0f;
			private float _interactionAngleVelocity = 0f;
			private Vector2 _interactionDirection = Vector2.right;

			private ITInteractable _selectedInteractable = null;
			private TInteractionState _interactionState = TInteractionState.None;

			public float CurrentInteractionAngle => _currentInteractionAngle;
			public Vector2 InteractingDirection => _interactionDirection;

			public ITInteractable SelectedInteractable => _selectedInteractable;
			public TInteractionState InteractionState => _interactionState;
			#endregion

			#region Behaviour
			public override void OnUpdate()
			{
				if (Master.CanPerformActions == false) { return; }

				HandleComputeInteractingDirection();
				HandleComputeNearestInteractable();
				HandleCheckForInteract();
			}
			private void HandleComputeInteractingDirection()
			{
				if (Controller != null && Controller.InputingMovement)
				{
					Vector2 dir = Controller.MoveInput.normalized;

					float targetAngle = dir.y < 0 ? -Mathf.Acos(dir.x) : Mathf.Acos(dir.x);
					targetAngle *= Mathf.Rad2Deg;

					_currentInteractionAngle = Mathf.SmoothDampAngle(_currentInteractionAngle, targetAngle, ref _interactionAngleVelocity, _data._interactionDirectionRotateSmoothTime);


					_interactionDirection = Controller.MoveInput.normalized;
				}
			}
			private void HandleComputeNearestInteractable()
			{
				Collider2D coll = Physics2D.OverlapCircle(Position, _data._interactionDistance, _data._whatIsInteractable);
				if (coll == null) 
				{
					DeselectInteractable();
					return;
				}

				ITInteractable interactable = coll.GetComponentInParent<ITInteractable>();
				if (interactable != null)
				{
					SelectInteractable(interactable);
				}
				else
				{
					DeselectInteractable();
				}
			}
			private void HandleCheckForInteract()
			{
				if (Controller.Interact == true && _selectedInteractable != null)
				{
					_selectedInteractable.OnStopInteract += OnInteractableStopInteraction;
					_interactionState = TInteractionState.Interacting;
					_selectedInteractable.StartInteract();
					OnStartInteract.Invoke(Master, _selectedInteractable);
				}
			}
			#endregion

			#region Utilities
			private void SelectInteractable(ITInteractable interactable)
			{
				if (_selectedInteractable != interactable)
				{
					if (_selectedInteractable != null)
					{
						OnDeselectInteractable.Invoke(Master, _selectedInteractable);
					}
					_selectedInteractable = interactable;
					OnSelectInteractable?.Invoke(Master, _selectedInteractable);
				}
			}
			private void DeselectInteractable()
			{
				if (_selectedInteractable != null)
				{
					OnDeselectInteractable.Invoke(Master, _selectedInteractable);
					_selectedInteractable = null;
				}
			}
			#endregion

			#region Events
			public event Action<TEntity, ITInteractable> OnSelectInteractable;
			public event Action<TEntity, ITInteractable> OnDeselectInteractable;
			public event Action<TEntity, ITInteractable> OnStartInteract;
			public event Action<TEntity, ITInteractable> OnStopInteract;

			private void OnInteractableStopInteraction(ITInteractable interactable)
			{
				_interactionState = TInteractionState.None;
				interactable.OnStopInteract -= OnInteractableStopInteraction;
				OnStopInteract?.Invoke(Master, interactable);
			}
			#endregion
		}
	}
}