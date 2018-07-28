using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLocation : MonoBehaviour {

    [SerializeField] private Text text;

	// Use this for initialization
	void Start () {
        //Turn on location Services
        Input.location.Start(10.0f,10.0f);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateLocation();
	}

    private void UpdateLocation()
    {
        //Do nothing if location services are not available
        if(Input.location.isEnabledByUser)
        {
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;

            text.text = "Lattitude:" + lat + "Longitude:" + lon;
        }
    }
}
