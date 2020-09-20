using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class CheatSystem : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.K))
			{
				TEntity.Player.AddMoney(100);
			}
		}
	}
}