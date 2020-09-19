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
		[SerializeField] private Rigidbody _rigidbody;

		[Header("Visual")]
		[Space]
		[SerializeField] private Transform _visual;

		public Transform Body => _body;
		public Transform Collisions => _collisions;
		public Rigidbody Rigidbody => _rigidbody;

		public Transform Visual => _visual;
		#endregion

		#region ITEntityData
		TEntity ITEntityData.Master => _master;
		TEntityReferences ITEntityData.References => this;
		#endregion

		#region Editor
		private void OnValidate()
		{
			_master = GetComponent<TEntity>();
		}
		#endregion
	}
}