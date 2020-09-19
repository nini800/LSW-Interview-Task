using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityAnimations", menuName = "Entity/Components/Animations", order = 100)]
	public class TEntityAnimationsComponent : TEntityComponentBase
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityAnimations(this, master);
		}

		public class TEntityAnimations : TEntityComponent
		{
			#region Construction
			public TEntityAnimations(TEntityAnimationsComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityAnimationsComponent _data;
			public new TEntityAnimationsComponent Data => _data;
			#endregion
		}
	}
}