using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fugu : Fish
{
	protected override void EatenComboProc(ComboManager combo, TextGenerater txtGen)
	{
		combo.Combo(0, AddedTime);         // ���Ԃ̓R���{�������炷
		float time = combo.CombodTime;

		combo.ResetCombo();                     // �R���{���Z�b�g

		txtGen.GenScoreText(0, transform.position);
		txtGen.GenTimeText(time, transform.position);
	}
}
