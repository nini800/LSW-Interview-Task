using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityInteractions", menuName = "Entity/Components/Interactions", order = 100)]
	public class TEntityInteractionsComponent : TEntityComponentBase
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityInteractions(this, master);
		}

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
			#endregion
		}
	}
}