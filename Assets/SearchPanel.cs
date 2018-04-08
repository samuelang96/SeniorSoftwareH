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
		bool hasItemAlready = false;
		Debug.Log ("Adding Item");
		for (int i = 0; i < am.myLists [slv.index].products.Count; i++) {
			if (am.myLists [slv.index].products [i].data.name == lb.buttonText.text) {
				hasItemAlready = true;
				am.myLists [slv.index].IncrementProduct (i, 1);
			}
		}
		if (!hasItemAlready) {
			am.myLists [slv.index].Add (am.products [lb.index]);
		}
		RefreshSearchList ();
	}

	public void SubItem (ListButton lb){
		bool hasItemAlready = false;
		for (int i = 0; i < am.myLists [slv.index].products.Count; i++) {
			if (am.myLists [slv.index].products [i].data.name == lb.buttonText.text) {
				hasItemAlready = true;
				am.myLists [slv.index].IncrementProduct (i, -1);
			}
		}
		RefreshSearchList ();
	}

	public void ToggleColor (Button b){
		b.GetComponent<Image> ().color = Color.green;
	}

	void RefreshSearchList(){
		for (int i = 0; i < buttons.Count; i++) {
			Destroy (buttons [i].gameObject);
		}

		buttons = new List<GameObject> ();
		for (int i = 0; i < am.products.Count; i++) {
			if (searchBar.text != "" && am.products [i].data.name.Contains (searchBar.text)) {
				GameObject newButton = Instantiate (button, buttonSpawn.transform);
				ListButton lb = newButton.GetComponent<ListButton> ();
				buttons.Add (newButton);
				lb.index = i;
				lb.buttonText.text = am.products [i].data.name;
				lb.countText.text = "0";
				for (int j = 0; j < am.myLists [slv.index].products.Count; j++) {
					if (am.myLists [slv.index].products [j].data.name == lb.buttonText.text) {
						lb.countText.text = am.myLists [slv.index].productCounts [j].ToString ();
					}
				}
			}
		}
	}


	IEnumerator SearchRoutine(){
		while (true) {
			yield return new WaitForSeconds (1);
			RefreshSearchList ();
		}
	}
}
