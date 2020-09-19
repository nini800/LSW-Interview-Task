using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "PlayerController", menuName = "Entity/Components/PlayerController", order = 100)]
	public class TEntityPlayerControllerComponent : TEntityControllerComponent
	{
		#region Fields, Getters
		[Header("Move Input")]
		[Space]
		[SerializeField, Range(0f, 1f)] private float _moveInputDeadZone = 0.25f;

		public float MoveInputDeadZone => _moveInputDeadZone;
		#endregion
		#region Component Building
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityPlayerController(this, master);
		}
		#endregion

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

				float moveInputSqrMagn = moveInput.sqrMagnitude;

				//Clamp input to unit vector if it exceeds 1 of magnitude.
				if (moveInputSqrMagn > 1f)
				{
					return moveInput.normalized;
				}

				//Manually add a magnitude based deadzone to prevent unity per-axis
				//deadzone to make controlling our character feel weird
				if (moveInputSqrMagn < (_data._moveInputDeadZone * _data._moveInputDeadZone))
				{
					return Vector2.zero;
				}
				else
				{
					float moveInputMagnitude = moveInput.magnitude;
					float moveInputTweakedMagnitude = moveInputMagnitude;

					moveInputMagnitude -= _data._moveInputDeadZone;
					moveInputMagnitude /= (1 - _data._moveInputDeadZone);

					//moveInput / moveInputMagnitude is just moveInput.normalized but we skip
					//doing the Sqrt again.
					return (moveInput / moveInputMagnitude) * moveInputTweakedMagnitude;
				}
			}
			#endregion
		}
	}
}