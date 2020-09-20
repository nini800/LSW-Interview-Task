using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
	public enum TMovementState
	{
		None,
		Idle,
		Moving
	}
	public enum TMovementDirection
	{
		None,
		Right,
		Up,
		Left,
		Down
	}
	public enum TInteractionState
	{
		None,
		Interacting
	}

	public enum TBodySocket
	{
		Hat,
		Shirt_Bust,
		Shirt_RightArm,
		Shirt_LefttArm,
		Pants_Pubic,
		Pants_PubicAbove,
		Pants_RightUpperLeg,
		Pants_LeftUpperLeg,
		Pants_RightLowerLeg,
		Pants_LefttLowerLeg,
		Shoes_Right,
		Shoes_Left,
	}

}