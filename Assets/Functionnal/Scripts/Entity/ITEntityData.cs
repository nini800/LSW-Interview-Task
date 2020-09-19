using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public interface ITEntityData
	{
		TEntity Master { get; }
		TEntityReferences References { get; }

		TEntityControllerComponent.TEntityController Controller { get; }
		TEntityMovementsComponent.TEntityMovements Movements { get; }
		TEntityInteractionsComponent.TEntityInteractions Interactions { get; }
		TEntityVisualComponent.TEntityVisual Visual { get; }
		TEntityAnimationsComponent.TEntityAnimations Animations { get; }

		Vector2 Position { get; }
		Vector2 Center { get; }
	}
}