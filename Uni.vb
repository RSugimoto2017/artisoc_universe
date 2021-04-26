Univ_Init{
	Dim myAgt as Agt
	Dim myAgtSet as AgtSet
	Dim i as Integer

	For i = 1 To Universe.init_male
		myAgt = CreateAgt(Universe.ground.male)
		myAgt.color = COLOR_GREEN
	Next i
	/*ランダムにエージェント生成*/
	MakeAgtSet(myAgtSet, Universe.ground.male)
	RandomPutAgtSet(myAgtSet)
	For i = 1 To Universe.init_female
		myAgt = CreateAgt(Universe.ground.female)
		myAgt.color = COLOR_GREEN
	Next i
	MakeAgtSet(myAgtSet, Universe.ground.female)
	RandomPutAgtSet(myAgtSet)
}
Univ_Step_Begin{

}

Univ_Step_End{
	Dim myAgtSet As AgtSet
	Dim myAgtSet2 As AgtSet
	Dim myAgt As Agt
	Dim myAgt2 As Agt
	Dim final_female as Integer
	Dim final_male as Integer
	DIm final_child as Integer
	Dim people as Integer

	Universe.step_count = GetCountStep()

	final_female = 0
	final_male = 0
	final_child = 0
	people = 0
	MakeAgtSet(myAgtSet, Universe.ground.male)
		For Each myAgt In myAgtSet
			If myAgt.color == COLOR_BLUE Then
				final_male = final_male + 1
				people = people + 1
			ElseIf myAgt.color == COLOR_GREEN Then
				final_child = final_child + 1
				people = people + 1
			End If
		Next myAgt

	MakeAgtSet(myAgtSet2, Universe.ground.female)
		For Each myAgt2 In myAgtSet2
			If myAgt2.color == COLOR_RED Then
				final_female = final_female + 1
				people = people + 1
			ElseIf myAgt2.color == COLOR_GREEN Then
				final_child = final_child + 1
				people = people + 1
			End If
		Next myAgt2

		//finish condition
		If people == 0 Then
			PrintLn("finish! : All people were dead... : at" & Universe.step_count & "step")
			ExitSimulation()
		End if

		//finish condition2
		If people >= (Universe.init_male * 2)+(Universe.init_female * 2) Then
			PrintLn("finish! : people were increased! There are" & people & "people. male : "& final_male & " female : "& final_female &" child : "& final_child &"at"& Universe.step_count &"step")
			ExitSimulation()
		End if

		//finish condition3
		If Universe.step_count >= 10000 Then
			PrintLn("finish! : There are" & people & "people. male : "& final_male & " female : "& final_female &" child : "& final_child&"at"& Universe.step_count &"step")
			ExitSimulation()
		End if

		Universe.ctMale = final_male
		Universe.ctFemale = final_female
		Universe.ctChild = final_child
		Universe.ctPeople = people
		
}

Univ_Finish{

}