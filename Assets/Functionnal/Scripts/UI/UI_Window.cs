using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class UI_Window : MonoBehaviour
	{
		public virtual void Open()
		{
			gameObject.SetActive(true);
		}

		public virtual void Close()
		{
			gameObject.SetActive(false);
		}
	}
}