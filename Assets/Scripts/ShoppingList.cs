using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShoppingList {
	public string name;
	public List<Product> products;
	public List<int> productCounts;
	// Use this for initialization
	public ShoppingList(){
		products = new List<Product> ();
		productCounts = new List<int> ();
	}
	public ShoppingList(string newName){
		name = newName;
		products = new List<Product> ();
		productCounts = new List<int> ();
	}

	public void Add(Product p){
		products.Add (p);
		productCounts.Add (1);
	}


	public void RemoveAt(int i){
		products.RemoveAt (i);
		productCounts.RemoveAt (i);
	}

	public void IncrementProduct(int index, int amount){
		productCounts [index] += amount;
		if (productCounts [index] <= 0) {
			productCounts.RemoveAt (index);
			products.RemoveAt (index);
		}
	}
}
