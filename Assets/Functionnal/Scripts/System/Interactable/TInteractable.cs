using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class TInteractable : MonoBehaviour, ITInteractable
	{
		[SerializeField] private GameObject _widget;
		[SerializeField] private SpriteRenderer[] _interactableRenderers;

		public GameObject Widget => _widget;
		public SpriteRenderer SpriteRenderer => _interactableRenderers.Length > 0 ? _interactableRenderers[0] : null;
		public SpriteRenderer[] SpriteRenderers => _interactableRenderers;

		public virtual void StartInteract()
		{
			OnStartInteract?.Invoke(this);
		}

		public virtual void StopInteract()
		{
			OnStopInteract?.Invoke(this);
		}

		public event Action<ITInteractable> OnStartInteract;
		public event Action<ITInteractable> OnStopInteract;
	}
}