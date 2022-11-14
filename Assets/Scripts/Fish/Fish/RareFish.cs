using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareFish : Fish
{
	protected override void EatenComboProc(ComboManager combo, TextGenerater txtGen)
	{
		combo.Combo(AddedScore, AddedTime);

		txtGen.GenScoreText(combo.CombodScore, transform.position);
		txtGen.GenTimeText(combo.CombodTime, transform.position);
	}
}
