using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class ShirtStand : TInteractable
	{
		public override void StartInteract()
		{
			Invoke("StopInteract", 1f);
		}
	}
}