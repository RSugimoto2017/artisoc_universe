Agt_Init{
	
	My.color = COLOR_GREEN
	My.speed = 0.1
	
	Turn(Rnd()*360)
	My.counter = 0
	My.Max = Rnd()*150 + 50 //50~200‚Ì—”
	My.age = 0
}

Agt_Step{
	Dim childRate as Double
	Dim threeChild as Double
	Dim twoChild as Double
	DIm oneChild as Double
	Dim noChild as Double
	Dim i as Integer
	Dim myAgt as Agt
	
	If My.age > Universe.min_age_female Then
		My.color = COLOR_RED
	End If
	
	/*•Ç‚É‚Ô‚Â‚©‚é‚Æ•ûŒü“]Š·*/
	If Forward(My.speed) <> -1 Then
		Turn(Rnd()*360)
	End If

	/*counter‚ª50~200step‚Ìƒ‰ƒ“ƒ_ƒ€‚ÈãŒÀˆÈ‰º‚É‚È‚é‚Æ•ûŒü“]Š·*/
	If My.counter > My.Max  Then
		Turn(Rnd()*360)
		My.counter = 0
		My.Max = Rnd()*150 + 50
	Else
		My.counter = My.counter + 1
	End If

	If My.color == COLOR_RED Then
		MakeOneAgtSetAroundOwn(My.neighbor, 1,Universe.ground.male, False) 
		If CountAgtSet(My.neighbor) > 0 Then
			myAgt = GetAgt(My.neighbor, 0)
			If myAgt.color == COLOR_BLUE Then
				childRate = (Rnd() * 1000)
				threeChild = (Universe.threechildren_rate) * 1000
				noChild = (1000 - threeChild) * 3 / 39
				oneChild = (1000 - threeChild) * 8 / 39
				twoChild = (1000 - threeChild) * 28 / 39
				
				If childRate < noChild Then
				ElseIf noChild <= childRate and childRate < (noChild + oneChild) Then
					If Rnd() > 0.5 Then
						CreateAgt(Universe.ground.male)
					Else
						CreateAgt(Universe.ground.female)
					End If
				
				ElseIf (noChild + oneChild) <= childRate and childRate < (noChild + oneChild + twoChild) Then
					For i = 1 To 2
						If Rnd() > 0.5 Then
							CreateAgt(Universe.ground.male)
						Else
							CreateAgt(Universe.ground.female)
						End If
					Next i
				Else
					For i = 1 To 3
						If Rnd() > 0.5 Then
							CreateAgt(Universe.ground.male)
						Else
							CreateAgt(Universe.ground.female)
						End If
					Next i
				End If
				KillAgt(My)
			End If
			ClearAgtSet(My.neighbor)
		End If
	End If

	If My.age > Universe.max_age_female Then
		KillAgt(My)
	End If

	Forward(My.speed)
	My.age = My.age + 0.02
}