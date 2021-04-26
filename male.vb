Agt_Init{
	
	My.color = COLOR_GREEN
	My.speed = 0.1

	Turn(Rnd()*360)//初期方向指定
	My.counter = 0//ステップ数のカウント
	My.Max = Rnd()*150 + 50 //50~200の乱数
}

Agt_Step{
	Dim myAgt as Agt
	
	/*出産可能最低年齢より自分の年が上回れば青になる*/
	If My.age > Universe.min_age_male Then
		My.color = COLOR_BLUE
	End If

	/*壁にぶつかると方向転換*/
	If Forward(My.speed) <> -1 Then
		Turn(Rnd()*360)
	End If

	/*counterが100~200stepのランダムな上限以下になると方向転換*/
	If My.counter > My.Max  Then
		Turn(Rnd()*360)
		My.counter = 0
		My.Max = Rnd()*100 + 100
	Else
		My.counter = My.counter + 1
	End If

	/*衝突すると自分が消える*/
	If My.color == COLOR_BLUE Then　
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