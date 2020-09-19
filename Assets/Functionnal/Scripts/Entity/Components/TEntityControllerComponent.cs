using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public abstract class TEntityControllerComponent : TEntityComponentBase
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityController(this, master);
		}

		public class TEntityController : TEntityComponent
		{
			#region Construction
			public TEntityController(TEntityControllerComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityControllerComponent _data;
			public new TEntityControllerComponent Data => _data;

			protected bool inputingMovement;
			protected Vector2 moveInput;

			public bool InputingMovement => inputingMovement;
			public Vector2 MoveInput => moveInput;
			#endregion
		}
	}
}