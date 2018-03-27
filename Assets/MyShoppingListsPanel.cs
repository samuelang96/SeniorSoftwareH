using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShoppingListsPanel : MonoBehaviour {
	public GameObject buttonSpawn;
	public GameObject listButton;
	List<GameObject> listButtons;
	public AppManager am;
	// Use this for initialization
	void Start () {
		listButtons = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillButtonList(){
		Debug.Log (am.myLists.Count);
		for (int i = 0; i < am.myLists.Count; i++) {
			GameObject newButton = Instantiate (listButton, buttonSpawn.transform);
			newButton.GetComponent<ListButton> ().index = i;
			newButton.GetComponent<ListButton> ().buttonText.text = am.myLists [i].name;
		}
		listButton.SetActive (false);
	}
}
