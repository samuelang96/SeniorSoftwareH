using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//{"y":2.0,"x":1.0,"price":244,"name":"Monster Energy Zero Ultra","id":1,"ean":"0070847012474"}
//{"y":3.0,"x":20.0,"price":875,"name":"Clorox Bleach Pen Gel","id":2,"ean":"0044600046907"}
//{"y":32.0,"x":10.0,"price":420,"name":"General Mills Honey Nut Cheerios Sweetened Whole Grain Oat Cereal","id":3,"ean":"0016000275270"}
public class AppManager : MonoBehaviour {
	public RequestsManager rm;
	// Use this for initialization
	string p1 = "0070847012474";
	string p2 = "0044600046907";
	string p3 = "0016000275270";
	public List<ShoppingList> myLists;
	public List<Product> products;
	public ShoppingList sl1;
	public ShoppingList sl2;

	//string p1 = "{"y":2.0,"x":1.0,"price":244,"name":"Monster Energy Zero Ultra","id":1,"ean":"0070847012474"}"
	void Start () {
		myLists = new List<ShoppingList> ();
		//myLists = new List<ShoppingList> ();
		//Debug.Log ("JSON STRING: ");
		//Product p = new Product();
		//string json = JsonUtility.ToJson(p);
		//Debug.Log (json);
		//Product p2 = new Product (json);

		rm.GetProduct(p1);
		rm.GetProduct(p2);
		rm.GetProduct(p3);

		//rm.GetProduct(p1);
		//rm.GetProduct(p1);
		//Product p = new Product();
		//p.ToJsonString ();
		sl1 = new ShoppingList("My List 1");
		sl2 = new ShoppingList("List Two");

		StartCoroutine (LoadUp ());

	}

	public IEnumerator LoadUp(){
		yield return new WaitForSeconds (1);
		sl1.Add (products [0]);
		sl1.Add (products [1]);
		sl2.Add (products [1]);
		sl2.Add (products [2]);
		myLists.Add (sl1);
		myLists.Add (sl2);
		Debug.Log ("MY LISTS: " + myLists.Count);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
