Agt_Init{
	
	My.color = COLOR_GREEN
	My.speed = 0.1

	Turn(Rnd()*360)//���������w��
	My.counter = 0//�X�e�b�v���̃J�E���g
	My.Max = Rnd()*150 + 50 //50~200�̗���
}

Agt_Step{
	Dim myAgt as Agt
	
	/*�o�Y�\�Œ�N���莩���̔N������ΐɂȂ�*/
	If My.age > Universe.min_age_male Then
		My.color = COLOR_BLUE
	End If

	/*�ǂɂԂ���ƕ����]��*/
	If Forward(My.speed) <> -1 Then
		Turn(Rnd()*360)
	End If

	/*counter��100~200step�̃����_���ȏ���ȉ��ɂȂ�ƕ����]��*/
	If My.counter > My.Max  Then
		Turn(Rnd()*360)
		My.counter = 0
		My.Max = Rnd()*100 + 100
	Else
		My.counter = My.counter + 1
	End If

	/*�Փ˂���Ǝ�����������*/
	If My.color == COLOR_BLUE Then�@
		MakeOneAgtSetAroundOwn(My.neighbor, 1,Universe.ground.female, False) 
		If CountAgtSet(My.neighbor) > 0 Then
			myAgt = GetAgt(My.neighbor, 0)
			If myAgt.color == COLOR_RED Then
			KillAgt(My)
			End If
			ClearAgtSet(My.neighbor)
		End If
	End If

	If My.age > Universe.max_age_male Then
		KillAgt(My)
	End If

	Forward(My.speed)
	My.age = My.age + 0.02
}