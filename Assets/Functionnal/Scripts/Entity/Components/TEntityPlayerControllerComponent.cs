using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "PlayerController", menuName = "Entity/Components/PlayerController", order = 100)]
	public class TEntityPlayerControllerComponent : TEntityControllerComponent
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityPlayerController(this, master);
		}

		public class TEntityPlayerController : TEntityController
		{
			#region Construction
			public TEntityPlayerController(TEntityPlayerControllerComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityPlayerControllerComponent _data;
			public new TEntityPlayerControllerComponent Data => _data;
			#endregion

			#region Behaviour
			/// <summary>
			/// Need base
			/// </summary>
			public override void OnUpdate()
			{
				HandleMovementsInputs();
			}
			private void HandleMovementsInputs()
			{
				moveInput = ComputeMoveInput();
				inputingMovement = moveInput.sqrMagnitude >= Mathf.Epsilon;
			}
			#endregion

			#region Utilities
			private Vector2 ComputeMoveInput()
			{
				Vector2 moveInput = Vector2.zero;

				moveInput.x = Input.GetAxis("Horizontal");
				moveInput.y = Input.GetAxis("Vertical");

				return moveInput.normalized;
			}
			#endregion
		}
	}
}