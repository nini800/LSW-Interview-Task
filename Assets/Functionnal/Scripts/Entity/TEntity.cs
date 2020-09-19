using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class TEntity : MonoBehaviour, ITEntityData
	{
		#region Vars, Fields, Getters
		[Header("Identity")]
		[Space]
		[SerializeField] protected string entityName;

		[Header("References")]
		[Space]
		[SerializeField] private TEntityReferences _references;
		#endregion

		#region ITEntityData
		TEntity ITEntityData.Master => this;
		TEntityReferences ITEntityData.References => _references;
		#endregion

		#region Behaviour
		private void Awake()
		{
			
		}

		private void Update()
		{
			
		}
		#endregion
	}
}