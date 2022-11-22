using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface Istates {

	void Entre(); // Initialization will be here

	void Exection(); // What the state will continously does when it is plugged in

	void Exit(); // What the state will do when it is going to be changed.
}
