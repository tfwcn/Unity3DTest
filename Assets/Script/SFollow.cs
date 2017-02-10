using UnityEngine;
using System.Collections;

public class SFollow : MonoBehaviour {
    public Vector3 position = new Vector3(0, 0, 0);
    public string objName = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameObject obj = GameObject.Find(objName);
        transform.position = obj.transform.position + position;
	}
}
