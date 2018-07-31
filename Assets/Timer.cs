using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private float time = 0.0f;

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        print(time);
	}
}
