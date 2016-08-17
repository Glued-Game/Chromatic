﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPattern {

    Stack<SpawnCommand> pattern = new Stack<SpawnCommand>();
	bool wait = false;
	Color a;
	Color b;
	Color c;

    // Use this for initialization
	public SpawnPattern(int p, int scheme) {
		if (scheme == 1) {
			a = ColorList.orange;
			b = ColorList.purple;
			c = ColorList.green;
		} else if (scheme == 2) {
			b = ColorList.orange;
			a = ColorList.purple;
			c = ColorList.green;
		} else {
			c = ColorList.orange;
			b = ColorList.purple;
			a = ColorList.green;
		}

        //set pattern based on p
		switch (p) {
			case 1: 
				pattern.Push (new SpawnCommand (10, 6, 3, a));
				wait = true;
				break;
			case 2:
				pattern.Push (new SpawnCommand (10, 6, 0, b));
				pattern.Push (new SpawnCommand (-10, 6, 0, c));
				wait = true;
				break;
			case 3:
				pattern.Push (new SpawnCommand (12, 6, 3, b));
				pattern.Push (new SpawnCommand (12, 0, 0, b));
				pattern.Push (new SpawnCommand (12, -6, 0, b));
                wait = true;
                break;
            case 4:
				pattern.Push (new SpawnCommand (-12, 6, 3, c));
				pattern.Push (new SpawnCommand (-12, 0, 0, c));
				pattern.Push (new SpawnCommand (-12, -6, 0, c));
                wait = true;
                break;
            case 5:
				pattern.Push (new SpawnCommand (8, -10, 3, a));
				pattern.Push (new SpawnCommand (0, 10, 0, a));
				pattern.Push (new SpawnCommand (-8, -10, 0, a));
				wait = true;
				break;
            case 6:
                //FIXED
                float leveltimer = 0.2f;
                pattern.Push(new SpawnCommand(-10, 10, leveltimer+2f, a, "fixed"));
                pattern.Push(new SpawnCommand(-8, 10, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(-6, 10, leveltimer,a, "fixed"));
                pattern.Push(new SpawnCommand(-4, 10, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(-2, 10, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(0, 10, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(2, 10, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(4, 10, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(6, 10, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(8, 10, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(10, 10, leveltimer, a, "fixed"));
                wait = false;
                break;
            case 7:
                pattern.Push(new SpawnCommand(-12, 3, 3, a, "fixed"));
                pattern.Push(new SpawnCommand(-12, 0, 0, b, "fixed"));
                pattern.Push(new SpawnCommand(-12, -3, 0, c, "fixed"));
                break;
            case 8:
                leveltimer = 0.2f;
                //FIXED
                pattern.Push(new SpawnCommand(-10, 12, leveltimer+2f, b, "fixed"));
                pattern.Push(new SpawnCommand(-8, -12, leveltimer, b, "fixed"));
                pattern.Push(new SpawnCommand(-6, 12, leveltimer, b, "fixed"));
                pattern.Push(new SpawnCommand(-4, -12, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(-2, 12, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(0, -12, leveltimer, a, "fixed"));
                pattern.Push(new SpawnCommand(2, 12, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(4, -12, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(6, 12, leveltimer, c, "fixed"));
                pattern.Push(new SpawnCommand(8, -12, leveltimer, b, "fixed"));
                pattern.Push(new SpawnCommand(10, 12, leveltimer, b, "fixed"));
                wait = false;
                break;
            case 9:
                pattern.Push(new SpawnCommand(12, 3, 3, a, "fixed"));
                pattern.Push(new SpawnCommand(12, 0, 0, b, "fixed"));
                pattern.Push(new SpawnCommand(12, -3, 0, c, "fixed"));
                break;
            case 10:
                pattern.Push(new SpawnCommand(12, -10, 3f, a, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, b, "fixed"));
                pattern.Push(new SpawnCommand(12, -10, 0.3f, a, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, b, "fixed"));
                pattern.Push(new SpawnCommand(12, -10, 0.3f, a, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, b, "fixed"));
                pattern.Push(new SpawnCommand(12, -10, 0.3f, c, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, a, "fixed"));
                pattern.Push(new SpawnCommand(12, -10, 0.3f, c, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, a, "fixed"));
                pattern.Push(new SpawnCommand(12, -10, 0.3f, c, "fixed"));
                pattern.Push(new SpawnCommand(-12, -10, 0.3f, a, "fixed"));
                break;
            case 11:
                pattern.Push(new SpawnCommand(0, -8, 3f, c, "normal"));
                pattern.Push(new SpawnCommand(0, 8, 0f, c, "normal"));
                pattern.Push(new SpawnCommand(12, 0, 0f, b, "normal"));
                pattern.Push(new SpawnCommand(-12, 0, 0f, b, "normal"));
                break;
            case 12:
                pattern.Push(new SpawnCommand(-12, 3, 5f, a, "curve", false));
                pattern.Push(new SpawnCommand(-12, 0, 0, b, "curve", false));
                pattern.Push(new SpawnCommand(-12, -3, 0, c, "curve", false));
                break;
            case 13:
                pattern.Push(new SpawnCommand(12, 3, 0, a, "curve", true));
                pattern.Push(new SpawnCommand(12, 0, 0, b, "curve", true));
                pattern.Push(new SpawnCommand(12, -3, 0, c, "curve", true));
                pattern.Push(new SpawnCommand(-12, 2, 0, a, "curve", false));
                pattern.Push(new SpawnCommand(-12, -1, 0, b, "curve", false));
                pattern.Push(new SpawnCommand(-12, -4, 0, c, "curve", false));
                break;

        }
    }

    // Update is called once per frame
    void Update() {

    }

    //tells you if the pattern is complete
    public bool isComplete() {   
        if (pattern.Count == 0)
            return true;
        return false;
    }

	public bool isWaiting() {
		return wait;
	}

    //commented until enemy code is done
    public SpawnCommand getNext() {
        return pattern.Pop();
    }   
}
