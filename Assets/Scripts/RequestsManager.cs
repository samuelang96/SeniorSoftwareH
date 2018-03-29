using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class RequestsManager : MonoBehaviour {
	public Text productReturnText;
	public AppManager am;
	// Use this for initialization
	public Product gotProduct;

	void Start () {
		StartCoroutine(GetText());
		GetText ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetProduct(string barcode){
		StartCoroutine (GetProductRoutine (barcode));
	}
	//Third floor of Northrup.
	//browser 

	public IEnumerator GetProductRoutine(string barcode){
		while (barcode.Length < 13) {
			barcode = "0" + barcode;
		}
		UnityWebRequest www = UnityWebRequest.Get("http://heb.cs.trinity.edu/api/products/" + barcode);
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			Debug.Log(www.downloadHandler.text);

			// Or retrieve results as binary data
			byte[] results = www.downloadHandler.data;
		}
		Debug.Log ("grabbing product...");
		productReturnText.text = www.downloadHandler.text;
		gotProduct = new Product (www.downloadHandler.text);
		am.products.Add (new Product (www.downloadHandler.text));

	}

	IEnumerator GetText() {
		UnityWebRequest www = UnityWebRequest.Get("http://heb.cs.trinity.edu/api/products/" + "0070847012474");
		yield return www.SendWebRequest();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			// Show results as text
			// Or retrieve results as binary data
			//retiring at the end of this semester
			//Patricia Simonite Art Department
			//trinity id: 0035449

			byte[] results = www.downloadHandler.data;
		}
	}
}
