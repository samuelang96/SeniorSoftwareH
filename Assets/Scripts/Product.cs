using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product {
	public float y;
	public float x; 
	public int price;
	public string name;
	public int id;
	public string ean;

	public Product(){
		price = 875;
		name = "Clorox";
		id = 1;
		ean = "0044600046907";
		x = 1;
		y = 2;
	}

	public Product(string jsonString){
		Data d = JsonUtility.FromJson<Data> (jsonString);
		Product p = d.data;
		//Debug.Log (p.id);
		price = p.price;
		name = p.name;
		id = p.id;
		ean = p.ean;
		x = p.x;
		y = p.y;
	}

	public string ToJsonString(){
		Data d = new Data ();
		string json = JsonUtility.ToJson (d);
		Debug.Log(json);
		return json;
	}
}

[System.Serializable]
public class Data {
	public Product data;
	public Data(){
		data = new Product ();
	}
}
