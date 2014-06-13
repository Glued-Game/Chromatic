﻿//The color of the enemy, starts out either red, yellow, or blue
var color : Color = Color.white;

//The sprite renderer component of this object
var sprite : SpriteRenderer;

function Start () {
	sprite = GetComponent(SpriteRenderer);

	//For now, this just makes it a random color
	var num : int = Random.Range(1, 4);
	
	switch (num) {
		case 1: color = Color.red;
			break;
		case 2: color = Color.yellow;
			break;
		case 3: color = Color.blue;
			break;
		default: break;
	}
	
	sprite.color = color;
}

function Update () {

}