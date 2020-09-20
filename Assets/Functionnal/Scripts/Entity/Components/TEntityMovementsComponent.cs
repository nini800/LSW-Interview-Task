using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityMovements", menuName = "Entity/Components/Movements", order = 100)]
	public class TEntityMovementsComponent : TEntityComponentBase
	{
		#region Fields & Getters
		[Header("Parameters")]
		[Space]
		[SerializeField] private float _moveSpeed;

		public float MoveSpeed => _moveSpeed;
		#endregion

		#region Component Building
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityMovements(this, master);
		}
		#endregion

		public class TEntityMovements : TEntityComponent
		{
			#region Construction
			public TEntityMovements(TEntityMovementsComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityMovementsComponent _data;
			public new TEntityMovementsComponent Data => _data;

			private TMovementDirection _movementDirection = TMovementDirection.None;

			public TMovementDirection MovementDirection => _movementDirection;
			#endregion

			#region Behaviour
			public override void OnFixedUpdate()
			{
				if (Master.CanPerformActions == false) { return; }

				HandleMove();
				HandleComputeMoveDirection();
			}
			private void HandleMove()
			{
				if (Controller.InputingMovement == false)
				{
					References.Rigidbody.velocity = Vector2.zero;
				}
				else
				{
					References.Rigidbody.velocity = Controller.MoveInput * Data._moveSpeed;
				}
			}
			private void HandleComputeMoveDirection()
			{
				if (Controller.InputingMovement == false)
				{
					_movementDirection = TMovementDirection.None;
				}
				else
				{
					//Get the angle
					Vector2 moveDir = Controller.MoveInput.normalized;
					float moveAngle = (moveDir.y < 0 ? -Mathf.Acos(moveDir.x) : Mathf.Acos(moveDir.x));

					//To prevent negative angle
					if (moveAngle <= 0f) { moveAngle += Mathf.PI * 2f; }
					//To prevent above 2PI angle
					moveAngle %= Mathf.PI * 2f;

					//So we have angleStep = 1 / 8 of 2PI, and we have 8 possible directions
					float angleStep = Mathf.PI / 4f;

					//Now moveAngle will have 0 if we are going right, 1 if upright, 2 if up, etc.
					moveAngle /= angleStep;

					//We add +1 because of TMovementDirection.None taking the ID 0
					int movementDirectionIndex = Mathf.FloorToInt(moveAngle) + 1;

					//Finally, assign the movement direction
					_movementDirection = (TMovementDirection)movementDirectionIndex;
				}
			}
			#endregion

			#region Events
			public override void OnEnable()
			{
				Interactions.OnStartInteract += OnStartInteract;
			}
			public override void OnDisable()
			{
				Interactions.OnStartInteract -= OnStartInteract;
			}

			private void OnStartInteract(TEntity master, ITInteractable interactable)
			{
				References.Rigidbody.velocity = Vector2.zero;
				_movementDirection = TMovementDirection.None;
			}
			#endregion
		}
	}
}