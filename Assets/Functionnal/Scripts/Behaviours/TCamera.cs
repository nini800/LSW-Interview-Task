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
		[SerializeField] private Vector2 _cameraZoomLimits = new Vector2(2.5f, 10f);

		[Header("References")]
		[Space]
		[SerializeField] private TEntity _player;
		[SerializeField] private Camera _camera;

		private float _currentZoom;
		private Vector3 _velocity;

		private void Awake()
		{
			_currentZoom = Mathf.Sqrt(_camera.orthographicSize);
		}
		private void Update()
		{
			HandleFollowPlayer();
			HandleZoom();
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
		private void HandleZoom()
		{
			float input = Input.GetAxis("Zoom");
			_currentZoom += input;
			_currentZoom = Mathf.Clamp(_currentZoom, _cameraZoomLimits.x, _cameraZoomLimits.y);

			//Real orthographicSize is squared to have a linear feeling when zooming in and out
			_camera.orthographicSize = _currentZoom * _currentZoom;
		}
	}
}