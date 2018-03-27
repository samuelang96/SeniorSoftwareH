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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillWithList(ListButton lb){
		listButton.SetActive (true);

		ShoppingList sl = am.myLists[lb.index];
		index = lb.index;
		title.text = sl.name;
		for (int i = 0; i < sl.products.Count; i++) {
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
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

		ShoppingList sl = am.myLists[index];
		Debug.Log (sl.products.Count);
		title.text = sl.name;
		for (int i = 0; i < sl.products.Count; i++) {
			Debug.Log ("INSTANT!!!!");
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
			newProductButton.GetComponent<ListButton> ().index = i;
			newProductButton.GetComponent<ListButton> ().buttonText.text = sl.products [i].name;
		}
		listButton.SetActive (false);
	}

	public void DeleteProductInList(ListButton lb){
		Destroy (lb.gameObject);
	}
}
