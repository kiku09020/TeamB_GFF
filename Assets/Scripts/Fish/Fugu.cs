using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : Fish
{
	protected override void EatenComboProc(ComboManager combo, TextGenerater txtGen)
	{
		combo.Combo(0, AddedTime);         // 時間はコンボ数分減らす
		float time = combo.CombodTime;

		combo.ResetCombo();                     // コンボリセット

		txtGen.GenScoreText(0, transform.position);
		txtGen.GenTimeText(time, transform.position);
	}
}
