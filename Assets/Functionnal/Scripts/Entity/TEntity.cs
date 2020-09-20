using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class TEntity : MonoBehaviour, ITEntityData
	{
		#region Static
		public static TEntity Player;
		#endregion

		#region Vars, Fields, Getters
		[Header("Identity")]
		[Space]
		[SerializeField] private bool _isPlayer;
		[SerializeField] private string _entityName;
		[SerializeField] private float _height;
		[SerializeField] private int _startMoney;

		[Header("Components")]
		[Space]
		[SerializeField] private TEntityControllerComponent _controllerComponent;
		[SerializeField] private TEntityMovementsComponent _movementsComponent;
		[SerializeField] private TEntityInteractionsComponent _interactionsComponent;
		[SerializeField] private TEntityVisualComponent _visualComponent;
		[SerializeField] private TEntityAnimationsComponent _animationsComponent;

		[Header("References")]
		[Space]
		[SerializeField] private TEntityReferences _references;

		private int _money;
		private List<TEntityComponentBase.TEntityComponent> _components = new List<TEntityComponentBase.TEntityComponent>();

		private TEntityControllerComponent.TEntityController _controller;
		private TEntityMovementsComponent.TEntityMovements _movements;
		private TEntityInteractionsComponent.TEntityInteractions _interactions;
		private TEntityVisualComponent.TEntityVisual _visual;
		private TEntityAnimationsComponent.TEntityAnimations _animations;

		public string EntityName => _entityName;
		public float Height => _height;
		public int Money => _money;

		public TEntityControllerComponent.TEntityController Controller => _controller;
		public TEntityMovementsComponent.TEntityMovements Movements => _movements;
		public TEntityInteractionsComponent.TEntityInteractions Interactions => _interactions;
		public TEntityVisualComponent.TEntityVisual Visual => _visual;
		public TEntityAnimationsComponent.TEntityAnimations Animations => _animations;

		public bool CanPerformActions
		{
			get
			{
				if (Interactions.InteractionState == TInteractionState.Interacting)
				{
					return false;
				}

				return true;
			}
		}
		#endregion

		#region ITEntityData
		public TEntity Master => this;
		public TEntityReferences References => _references;

		public Vector2 Position => _references.Body.position;
		public Vector2 Center => _references.Body.position.ToV2().AddY(_height * 0.5f);
		#endregion

		#region Behaviour
		private void Awake()
		{
			CreateComponents();
			for (int i = 0; i < _components.Count; i++)
			{
				_components[i].OnAwake();
			}

			//In a real game, I would have made an entity manager for this kind of reference.
			if (_isPlayer == true)
			{
				Player = this;
			}


			//I would have done a separate component for money in a real game
			_money = _startMoney;
		}
		#region Components Creation
		private void CreateComponents()
		{
			//Order of lines here determines execution order of the components
			CreateComponent(_controllerComponent, ref _controller);
			CreateComponent(_movementsComponent, ref _movements);
			CreateComponent(_interactionsComponent, ref _interactions);
			CreateComponent(_visualComponent, ref _visual);
			CreateComponent(_animationsComponent, ref _animations);
		}
		private void CreateComponent<T, TT>(T componentData, ref TT _componentVar) where T : TEntityComponentBase where TT : TEntityComponentBase.TEntityComponent
		{
			_componentVar = (TT)componentData.BuildInstance(this);
			_components.Add(_componentVar);
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

		#region Utilities
		public void AddMoney(int money)
		{
			_money += money;
		}
		#endregion
	}
}