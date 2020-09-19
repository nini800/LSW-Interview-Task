using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace InterviewTask
{
	public class TCamera : MonoBehaviour
	{
		public static TCamera Instance;

		[Header("Parameters")]
		[Space]
		[SerializeField, Min(0f)] private float _cameraMovementSmoothTime = 0.1f;
		[SerializeField, Min(0f)] private float _cameraZoomSmoothTime = 0.1f;
		[SerializeField] private Vector2 _cameraZoomLimits = new Vector2(2.5f, 10f);

		[Header("References")]
		[Space]
		[SerializeField] private TEntity _player;
		[SerializeField] private Camera _camera;

		private float _currentZoom;
		private float _zoomTarget;
		private float _zoomVelocity;
		private Vector3 _movementVelocity;

		private void Awake()
		{
			_zoomTarget = Mathf.Sqrt(_camera.orthographicSize);
			_currentZoom = _zoomTarget;
			Instance = this;
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
				ref _movementVelocity,
				_cameraMovementSmoothTime);
		}
		private void HandleZoom()
		{
			float input = Input.GetAxis("Zoom");
			_zoomTarget += input;
			_zoomTarget = Mathf.Clamp(_zoomTarget, _cameraZoomLimits.x, _cameraZoomLimits.y);
			_currentZoom = Mathf.SmoothDamp(_currentZoom, _zoomTarget, ref _zoomVelocity, _cameraZoomSmoothTime);

			//Real orthographicSize is squared to have a linear feeling when zooming in and out
			_camera.orthographicSize = _currentZoom * _currentZoom;
		}
	}
}