using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListView : MonoBehaviour {

	public AppManager am;
	public Text title;
	public GameObject buttonSpawn;
	public GameObject listButton;

	public Text productTitle;
	public Text productPrice;

	public int index = 0;

	List<GameObject> listButtons;

	// Use this for initialization
	void Start () {
		listButtons = new List<GameObject> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ClearButtonList(){
		for (int i = 0; i < listButtons.Count; i++) {
			Destroy (listButtons [i].gameObject);
		}
		listButtons = new List<GameObject> ();

	}

	public void FillWithList(ListButton lb){
		listButton.SetActive (true);

		ShoppingList sl = am.myLists[lb.index];
		index = lb.index;
		title.text = sl.name;
		ClearButtonList ();

		for (int i = 0; i < sl.products.Count; i++) {
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
			listButtons.Add (newProductButton);
			newProductButton.GetComponent<ListButton> ().index = i;
			newProductButton.GetComponent<ListButton> ().buttonText.text = sl.products [i].name;
		}
		listButton.SetActive (false);
	}

	public void FillProductInfo(ListButton lb){
		Product p = am.myLists [index].products [lb.index];
		productTitle.text = p.name;
		productPrice.text = "$" + (p.price/100) + "." + (p.price % 100);
	}

	public void Refresh(){
		listButton.SetActive (true);
		ClearButtonList ();
		ShoppingList sl = am.myLists[index];
		Debug.Log (sl.products.Count);
		title.text = sl.name;
		for (int i = 0; i < sl.products.Count; i++) {
			Debug.Log ("INSTANT!!!!");
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
			listButtons.Add (newProductButton);
			newProductButton.GetComponent<ListButton> ().index = i;
			newProductButton.GetComponent<ListButton> ().buttonText.text = sl.products [i].name;
		}
		listButton.SetActive (false);
	}

	public void DeleteProductInList(ListButton lb){
		Destroy (lb.gameObject);
	}
}
