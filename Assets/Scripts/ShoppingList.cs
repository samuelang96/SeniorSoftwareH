using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShoppingList {
	public string name;
	public List<Product> products;
	// Use this for initialization
	public ShoppingList(){
		products = new List<Product> ();
	}
	public ShoppingList(string newName){
		name = newName;
		products = new List<Product> ();
	}

	public void Add(Product p){
		products.Add (p);
	}

	public void RemoveAt(int i){
		products.RemoveAt (i);
	}
}
