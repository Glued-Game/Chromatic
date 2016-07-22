﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    Transform target;
	public Color type;
	Controller gc;
	// Use this for initialization
	void Awake () {
		gc = GameObject.FindWithTag("GameController").GetComponent<Controller>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            //TODO: FIX THIS HORRIBLE MESS
            Quaternion newRotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.forward);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 500*Time.deltaTime);

            GetComponent< Rigidbody2D >().AddForce(transform.up * Time.deltaTime * 300);
        }
		if(!type.Equals(this.GetComponent<SpriteRenderer>().color)){
			this.GetComponent<SpriteRenderer> ().color = type;
		}
    }

	public void SetColor(Color color){
        type = color;
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" ) {
            if (this.type != other.GetComponent<Player>().type)
                other.GetComponent<Player>().Kill();
            else
                Destroy(this.gameObject);
        }
    }
}
