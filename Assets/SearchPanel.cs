using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour {
	public AppManager am;
	public ShoppingListView slv;

	public InputField searchBar;
	public GameObject buttonSpawn;
	public GameObject button;
	List<GameObject> buttons;
	// Use this for initialization
	void Start () {
		buttons = new List<GameObject> ();
		StartCoroutine (SearchRoutine ());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem (ListButton lb){
		am.myLists [slv.index].Add (am.products [lb.index]);
		Debug.Log (am.myLists [slv.index].products.Count);
	}

	public void ToggleColor (Button b){
		b.GetComponent<Image> ().color = Color.green;
	}

	IEnumerator SearchRoutine(){
		while (true) {
			yield return new WaitForSeconds (1);
			for (int i = 0; i < buttons.Count; i++) {
				Destroy (buttons [i].gameObject);
			}

			buttons = new List<GameObject> ();
			for (int i = 0; i < am.products.Count; i++) {
				if (searchBar.text != "" && am.products [i].name.Contains (searchBar.text)) {
					GameObject newButton = Instantiate (button, buttonSpawn.transform);
					ListButton lb = newButton.GetComponent<ListButton> ();
					buttons.Add (newButton);
					lb.index = i;
					lb.buttonText.text = am.products [i].name;
				}
			}
		}
	}
}
