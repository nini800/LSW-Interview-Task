using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public class UI_Game : MonoBehaviour
	{
		#region Static
		public static UI_Game Instance;
		#endregion

		#region Vars, Fields, Getters
		[Header("References")]
		[Space]
		[SerializeField] private UI_ClothesShop _clothesShop;

		public UI_ClothesShop ClothesShop => _clothesShop;
		#endregion

		#region Behaviour
		private void Awake()
		{
			Instance = this;
		}
		#endregion

	}
}