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
			#endregion

			#region Behaviour
			public override void OnFixedUpdate()
			{
				HandleMove();
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
			#endregion
		}
	}
}