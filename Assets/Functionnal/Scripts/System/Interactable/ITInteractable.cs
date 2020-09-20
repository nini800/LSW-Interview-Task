using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InterviewTask
{
	public interface ITInteractable
	{
		GameObject Widget { get; }
		SpriteRenderer SpriteRenderer { get; }
		SpriteRenderer[] SpriteRenderers { get; }

		event Action<ITInteractable> OnStartInteract;
		event Action<ITInteractable> OnStopInteract;

		void StartInteract();
		void StopInteract();
	}
}