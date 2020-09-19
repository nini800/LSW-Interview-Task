using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	[RequireComponent(typeof(TEntity))]
	public class TEntityReferences : MonoBehaviour, ITEntityData
	{
		#region Fields, Getters
		[Header("Main")]
		[Space]
		[SerializeField] private TEntity _master;

		[Header("Physics")]
		[Space]
		[SerializeField] private Transform _body;
		[SerializeField] private Transform _collisions;
		[SerializeField] private Rigidbody2D _rigidbody;

		[Header("Visual")]
		[Space]
		[SerializeField] private Transform _visualBody;

		public Transform Body => _body;
		public Transform Collisions => _collisions;
		public Rigidbody2D Rigidbody => _rigidbody;

		public Transform VisualBody => _visualBody;
		#endregion

		#region ITEntityData
		public TEntity Master => _master;
		public TEntityReferences References => this;

		public TEntityControllerComponent.TEntityController Controller => _master.Controller;
		public TEntityMovementsComponent.TEntityMovements Movements => _master.Movements;
		public TEntityInteractionsComponent.TEntityInteractions Interactions => _master.Interactions;
		public TEntityVisualComponent.TEntityVisual Visual => _master.Visual;
		public TEntityAnimationsComponent.TEntityAnimations Animations => _master.Animations;

		public Vector2 Position => _master.Position;
		public Vector2 Center => _master.Center;
		#endregion

		#region Editor
		private void OnValidate()
		{
			_master = GetComponent<TEntity>();
		}
		#endregion
	}
}