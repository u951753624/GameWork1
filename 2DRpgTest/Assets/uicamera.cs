using UnityEngine;
using System.Collections;

public class uicamera : MonoBehaviour {

    public GameObject Maincamera;
	// Use this for initialization
	void Start () {
        gameObject.transform.position = Maincamera.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Maincamera.transform.position;
    }
}
