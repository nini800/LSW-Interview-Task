using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace InterviewTask
{
	public class TCamera : MonoBehaviour
	{
		[Header("Parameters")]
		[Space]
		[SerializeField, Min(0f)] private float _cameraSmoothTime = 0.1f;

		[Header("References")]
		[Space]
		[SerializeField] private TEntity _player;

		private Vector3 _velocity;

		private void Update()
		{
			HandleFollowPlayer();
		}
		private void HandleFollowPlayer()
		{
			if (_player == null) { return; }

			transform.position = Vector3.SmoothDamp(
				transform.position,
				_player.Center.ToV3(transform.position.z),
				ref _velocity,
				_cameraSmoothTime);
		}
	}
}