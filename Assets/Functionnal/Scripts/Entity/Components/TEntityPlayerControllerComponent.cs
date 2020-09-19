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

		public class TEntityPlayerController : TEntityComponent
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