using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserLocation : MonoBehaviour {

    [SerializeField] private Text text;
    [Tooltip("In Meters")]
    [SerializeField] private float locationAccuracy = 10.0f;
    [Tooltip("In Meters")]
    [SerializeField] private float updateDistance = 1.0f;

    // Use this for initialization
    void Start () {
        //Turn on location Services
        Input.location.Start(locationAccuracy, updateDistance);
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
