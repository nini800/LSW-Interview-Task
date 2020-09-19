using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public interface ITEntityData
	{
		TEntity Master { get; }
		TEntityReferences References { get; }
	}
}