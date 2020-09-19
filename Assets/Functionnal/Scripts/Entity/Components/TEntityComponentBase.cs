using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace InterviewTask
{
	public abstract class TEntityComponentBase : ScriptableObject
	{
		public virtual TEntityComponent BuildInstance(TEntity master)
		{
			return new TEntityComponent(this, master);
		}
		
		public class TEntityComponent : ITEntityData
		{
			#region Construction
			public TEntityComponent(TEntityComponentBase data, TEntity master)
			{
				_data = data;
				_master = master;
			}
			#endregion

			#region Vars, Getters
			private TEntityComponentBase _data;
			private TEntity _master;

			public TEntityComponentBase Data => _data;
			#endregion

			#region ITEntityData
			public TEntity Master => _master;
			public TEntityReferences References => _master.References;

			public TEntityControllerComponent.TEntityController Controller => _master.Controller;
			public TEntityMovementsComponent.TEntityMovements Movements => _master.Movements;
			public TEntityInteractionsComponent.TEntityInteractions Interactions => _master.Interactions;
			public TEntityVisualComponent.TEntityVisual Visual => _master.Visual;
			public TEntityAnimationsComponent.TEntityAnimations Animations => _master.Animations;

			public Vector2 Position => _master.Position;
			public Vector2 Center => _master.Center;
			#endregion

			#region Behaviour
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnAwake()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnStart()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnEnable()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnDisable()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnFixedUpdate()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnUpdate()
			{

			}
			/// <summary>
			/// Do not need base
			/// </summary>
			public virtual void OnLateUpdate()
			{

			}
			#endregion
		}
	}
}