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
		[SerializeField, Min(0f)] private float _interactingDirectionRotateSmoothTime = 0.05f;
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
			private float _currentInteractingAngle = 0f;
			private float _interactingAngleVelocity = 0f;
			private Vector2 _interactingDirection = Vector2.right;

			public new TEntityInteractionsComponent Data => _data;
			public float CurrentInteractingAngle => _currentInteractingAngle;
			public Vector2 InteractingDirection => _interactingDirection;
			#endregion

			#region Behaviour
			public override void OnUpdate()
			{
				HandleComputeInteractingDirection();
			}
			private void HandleComputeInteractingDirection()
			{
				if (Controller != null && Controller.InputingMovement)
				{
					Vector2 dir = Controller.MoveInput.normalized;

					float targetAngle = dir.y < 0 ? -Mathf.Acos(dir.x) : Mathf.Acos(dir.x);
					targetAngle *= Mathf.Rad2Deg;

					_currentInteractingAngle = Mathf.SmoothDampAngle(_currentInteractingAngle, targetAngle, ref _interactingAngleVelocity, _data._interactingDirectionRotateSmoothTime);


					_interactingDirection = Controller.MoveInput.normalized;
				}
			}
			#endregion
		}
	}
}