using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScript : MonoBehaviour {

    string url = "";

    public float lat = 41.3911056f;
    public float lon = 2.1548483f;
    LocationInfo li;
    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;
    public enum mapType { roadmap, satellite, hybrid, terrain };
    public mapType mapSelected;
    public int scale;

    private bool loadingMap = false;

    private IEnumerator mapCoroutine;

    private void Start()
    {
        mapCoroutine = GetGoogleMap(lat, lon);
        StartCoroutine(mapCoroutine);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            print("new Map");
            mapCoroutine = GetGoogleMap(lat, lon);
            StartCoroutine(mapCoroutine);
        }
    }

    IEnumerator GetGoogleMap(float lat, float lon)
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat +","+ lon +
            "&zoom="+ zoom +"&size="+ mapWidth + "x"+ mapHeight +"&scale="+ scale +
            "&maptype="+ mapSelected +
            "&key=AIzaSyBd8uWGVeXThrT2SjbnMrAhQDiCp19gmlw";
        print(url);
        loadingMap = true;
        WWW www = new WWW(url);
        print(www.error);
        yield return www;
        loadingMap = false;
        //Assign downloaded map texture to Canvas Image
        gameObject.GetComponent<RawImage>().texture = www.texture;
        StopCoroutine(mapCoroutine);
    }

}
