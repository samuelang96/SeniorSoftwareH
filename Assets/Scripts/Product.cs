using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
	public Data data;

	public Product(){
		data = new Data ();
		data.price = 875;
		data.name = "Clorox";
		data.id = 1;
		data.ean = "0044600046907";
		data.x = 1;
		data.y = 2;
	}

	public Product(string jsonString){
		Product p = JsonUtility.FromJson<Product> (jsonString);
		data = new Data ();
		data = p.data;
		//Product p = d.data;
		//Debug.Log (p.id);


		Debug.Log ("LOADED PRODUCT: " + JsonUtility.ToJson(this));
	}

	public string ToJsonString(){
		//Data d = new Data ();
		//d.price = price;
		//d.name = name;
		//d.id = id;
		//d.ean = ean;
		//d.x = x;
		//d.y = y;
		string json = JsonUtility.ToJson (this);
		return json;
	}
}

[System.Serializable]
public class Data {
	public float y;
	public float x; 
	public int price;
	public string name;
	public int id;
	public string ean;
}
