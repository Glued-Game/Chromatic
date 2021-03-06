﻿var text : GUIText;
var tut_triangle : GameObject;
var tut_square : GameObject;
var done : boolean;
var player : player_controller;
var fader : fade_in;

function Start () {
	done = false;
}

function Update () {
	if (!done && (Input.touchCount > 0 || Input.GetButton("Fire1")))
		do_a_thing();
}

function do_a_thing () {
	done = true;
	fader.Fade ();
	
	text.text = "Move your finger near the circle to move!";
	var prevPos = player.transform.position;
    var actualPos = player.transform.position;
    while(prevPos == actualPos){
   		prevPos = player.transform.position;
   		yield WaitForSeconds(0.5);
   		actualPos = player.transform.position;
  	}
	text.text = "Nice job!";
	
	yield WaitForSeconds(2);
	
	text.text = "This triangle is your friend.\nPick it up to change your color.";
	var t1 : GameObject = Instantiate(tut_triangle, Vector3(3, 2, 0), transform.rotation);
	t1.GetComponent(friendly).SetColor(0);	//Red
	while(player.color != player.red){ 
		yield WaitForSeconds(0.5);
	}
	text.text = "Now pick up another triangle to\nchange into a secondary color.";
	var t2 : GameObject = Instantiate(tut_triangle, Vector3(-2, 1.5, 0), transform.rotation);
	t2.GetComponent(friendly).SetColor(2);	//blue
	while(player.color != player.purple){
		yield WaitForSeconds(0.5);
	}
	text.text = "Now run into an enemy\nof your color to destroy it.";
	var s1 : GameObject = Instantiate(tut_square, Vector3(0, 5, 0), transform.rotation);
	s1.GetComponent(enemy).SetColor(2);
	while(player.getMultiplier() < 2){
		yield WaitForSeconds(0.5);
		if(player.color == Color.white && s1 == null){
			s1 = Instantiate(tut_square, Vector3(0, 5, 0), transform.rotation);
			s1.GetComponent(enemy).SetColor(2);
		}
	}
	text.text = "Nice! Get combos to rack up more points";
	yield WaitForSeconds(2.5);
	text.text = "You can only attack \nrectangles of your color";
	yield WaitForSeconds(2.5);
	text.text = "Remember, collect triangles and attack rectangles!";
	yield WaitForSeconds(2.5);
	text.text = "Get ready!";
	yield WaitForSeconds(3);
	Application.LoadLevel("main");
	
}