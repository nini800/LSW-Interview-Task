using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[CreateAssetMenu(fileName = "EntityVisual", menuName = "Entity/Components/Visual", order = 100)]
	public class TEntityVisualComponent : TEntityComponentBase
	{
		public override TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityVisual(this, master);
		}

		public class TEntityVisual : TEntityComponent
		{
			#region Construction
			public TEntityVisual(TEntityVisualComponent data, TEntity master) : base(data, master)
			{
				_data = data;
			}
			#endregion

			#region Vars, Getters
			private TEntityVisualComponent _data;
			public new TEntityVisualComponent Data => _data;
			#endregion

			#region Behaviour
			public override void OnAwake()
			{
				HandleDisplayEntityName();
			}
			private void HandleDisplayEntityName()
			{
				if (References.NameDisplay != null)
				{
					References.NameDisplay.text = Master.EntityName;
				}
			}
			#endregion
		}
	}
}