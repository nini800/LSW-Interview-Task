using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace InterviewTask
{
	public class UI_MoneyText : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _txt;

		private float _currentMoney;
		private float _moneyVelocity;

		private void Update()
		{
			HandleUpdateCurrentMoney();
			_txt.text = Mathf.RoundToInt(_currentMoney) + "$";
		}
		private void HandleUpdateCurrentMoney()
		{
			_currentMoney = Mathf.SmoothDamp(_currentMoney, TEntity.Player.Money, ref _moneyVelocity, 0.2f);
		}
	}
}