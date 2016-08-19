﻿using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
    bool hidden;
    Color color;
    Controller gc;

    void Awake () {
        gc = GameObject.FindWithTag("GameController").GetComponent<Controller>();
        hidden = false;

        if (this.name == "Red") {
            color = ColorList.red;
        }
        if(this.name == "Blue") {
            color = ColorList.blue;
        }
        if (this.name == "Yellow") {
            color = ColorList.yellow;
        }

		this.GetComponent<SpriteRenderer> ().color = color;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.parent.position, new Vector3(0, 0, 1), 100f * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other) {
        // Change player color to w/e this is (Or calculate new color based on players color)
        if (other.tag == "Player" && !hidden) {
            Hide();
            gc.hp = gc.MAX_HP;
            other.gameObject.GetComponent<Player>().AddColor(this.color);
        }
    }

    public void Hide () {
        GetComponent<SpriteRenderer>().enabled = false;
        hidden = true;
    }

    public void Show () {
        StartCoroutine(WaitThenShow());
    }

    private IEnumerator WaitThenShow () {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animation>().Play();

        yield return new WaitForSeconds(0.25f);

        hidden = false;
    }
}
