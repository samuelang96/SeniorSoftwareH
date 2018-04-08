using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListView : MonoBehaviour {

	public AppManager am;
	public Text title;
	public InputField titleField;
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
		//title.text = sl.name;
		titleField.text = sl.name;
		Refresh ();
		/*

		ClearButtonList ();

		for (int i = 0; i < sl.products.Count; i++) {
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
			listButtons.Add (newProductButton);
			newProductButton.GetComponent<ListButton> ().index = i;
			newProductButton.GetComponent<ListButton> ().buttonText.text = sl.products [i].data.name;
		}*/
		listButton.SetActive (false);
	}

	public void FillProductInfo(ListButton lb){
		Product p = am.myLists [index].products [lb.index];
		productTitle.text = p.data.name;
		productPrice.text = "$" + (p.data.price/100) + "." + (p.data.price % 100);
	}

	public void Refresh(){
		listButton.SetActive (true);
		ClearButtonList ();
		ShoppingList sl = am.myLists[index];
		Debug.Log (sl.products.Count);
		//title.text = sl.name;
		titleField.text = sl.name;
		for (int i = 0; i < sl.products.Count; i++) {
			Debug.Log ("INSTANT!!!!");
			GameObject newProductButton = Instantiate (listButton, buttonSpawn.transform);
			listButtons.Add (newProductButton);
			newProductButton.GetComponent<ListButton> ().index = i;
			newProductButton.GetComponent<ListButton> ().buttonText.text = sl.products [i].data.name;
			newProductButton.GetComponent<ListButton> ().countText.text = sl.productCounts [i].ToString();
		}
		listButton.SetActive (false);
	}

	public void DeleteProductInList(ListButton lb){
		am.myLists [index].RemoveAt (lb.index);
		Destroy (lb.gameObject);
	}

	public void IncrementProductInList(ListButton lb){
		am.myLists [index].IncrementProduct (lb.index, 1);
		Refresh ();
	}
	public void DeincrementProductInList(ListButton lb){
		am.myLists [index].IncrementProduct (lb.index, -1);
		Refresh ();
	}
}
