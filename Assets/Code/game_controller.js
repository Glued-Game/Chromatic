﻿var over : boolean = false;
var can_restart: boolean = false;
private var bg_color : Color = Color(2/255, 20/255, 26/255, 0.05);

function Update () {
	//Exits the application if the player pressed the back button
	if (Input.GetButtonDown("Exit"))
		Application.Quit();
		
	if (over && !can_restart)
		if (Input.touchCount == 0)
			can_restart = true;

	if (over && can_restart && (Input.touchCount > 0 || Input.GetButtonDown("Fire1")))
		Application.LoadLevel(2);
		
	camera.backgroundColor = Color.Lerp(camera.backgroundColor, bg_color, .1);
}

function GameOver () {
	if (Input.touchCount == 0)
		can_restart = true;
	over = true;
}

function ChangeBackgroundColor (color : Color) {
	bg_color = color / 12;
}