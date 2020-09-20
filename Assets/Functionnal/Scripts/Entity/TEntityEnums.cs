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
		UpRight,
		Up,
		UpLeft,
		Left,
		DownLeft,
		Down,
		DownRight
	}
	public enum TInteractionState
	{
		None,
		Interacting
	}

	public enum TClothType
	{
		Hat,
		Shirt,
		Pants,
		Shoes
	}
	public enum TBodySocket
	{
		Hat,
		Hairs,
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