using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChangeManager : MonoBehaviour {
	public List<GameObject> panels; 
	// Use this for initialization
	void Start () {
		//ShowPanels ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HidePanels(){
		for (int i = 0; i < panels.Count; i++) {
			panels [i].transform.position = new Vector3 (1000, 0, 0);
		}
	}

	public void ShowPanels(){
		for (int i = 0; i < panels.Count; i++) {
			panels [i].transform.position = new Vector3 (0, 0, 0);
		}
	}

	public void ShowPanel(int i){
		HidePanels ();
		panels [i].transform.position = new Vector3 (0, 0, 0);
	}
}
