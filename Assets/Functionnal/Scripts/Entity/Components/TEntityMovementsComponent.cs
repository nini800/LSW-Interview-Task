using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityMovements", menuName = "Entity/Components/Movements", order = 100)]
	public class TEntityMovementsComponent : TEntityComponentBase
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityMovements(this, master);
		}

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
				base.OnFixedUpdate();
			}
			private void HandleVelocity()
			{

			}
			#endregion
		}
	}
}