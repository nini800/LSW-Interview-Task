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
		[SerializeField] private string _entityName;

		[Header("Components")]
		[Space]
		[SerializeField] private TEntityControllerComponent _controllerComponent;
		[SerializeField] private TEntityMovementsComponent _movementsComponent;
		[SerializeField] private TEntityMovementsComponent _interactionsComponent;
		[SerializeField] private TEntityMovementsComponent _visualComponent;
		[SerializeField] private TEntityMovementsComponent _animationsComponent;

		[Header("References")]
		[Space]
		[SerializeField] private TEntityReferences _references;

		private List<TEntityComponentBase.TEntityComponent> _components = new List<TEntityComponentBase.TEntityComponent>();

		private TEntityControllerComponent.TEntityController _controller;
		private TEntityMovementsComponent.TEntityMovements _movements;
		private TEntityInteractionsComponent.TEntityInteractions _interactions;
		private TEntityVisualComponent.TEntityVisual _visual;
		private TEntityAnimationsComponent.TEntityAnimations _animations;

		public string EntityName => _entityName;

		public TEntityControllerComponent.TEntityController Controller => _controller;
		public TEntityMovementsComponent.TEntityMovements Movements => _movements;
		public TEntityInteractionsComponent.TEntityInteractions Interactions => _interactions;
		public TEntityVisualComponent.TEntityVisual Visual => _visual;
		public TEntityAnimationsComponent.TEntityAnimations Animations => _animations;
		#endregion

		#region ITEntityData
		public TEntity Master => this;
		public TEntityReferences References => _references;
		#endregion


		#region Behaviour
		private void Awake()
		{
			CreateComponents();
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnAwake();
			}
		}
		#region Components Creation
		private void CreateComponents()
		{
			CreateComponent(_controllerComponent, ref _controller);
			CreateComponent(_movementsComponent, ref _movements);
			CreateComponent(_interactionsComponent, ref _interactions);
			CreateComponent(_visualComponent, ref _visual);
			CreateComponent(_animationsComponent, ref _animations);
		}
		private void CreateComponent<T, TT>(T componentData, ref TT _componentVar) where T : TEntityComponentBase where TT : TEntityComponentBase.TEntityComponent
		{
			_componentVar = (TT)componentData.BuildInstance(this);
		}
		#endregion

		private void Start()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnStart();
			}
		}

		private void OnEnable()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnEnable();
			}
		}

		private void OnDisable()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnDisable();
			}
		}

		private void FixedUpdate()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnFixedUpdate();
			}
		}

		private void Update()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnUpdate();
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnLateUpdate();
			}
		}
		#endregion
	}
}