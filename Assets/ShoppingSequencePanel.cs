using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingSequencePanel : MonoBehaviour {
	public GameObject tile;
	int width = 50;
	int height = 50;
	int start_x = 49;
	int start_y = 49;
	GameObject[] tile_grid;// = new GameObject[shop_width * shop_height];
	ShoppingList shoppingList;
	public Text current_item_text;
	List<Product> sorted_shopping_list;
	public Vector2 my_position;
	// Use this for initialization
	void Start () {
		tile_grid = new GameObject[width * height];
		//SpawnShopGrid ();
		//InitializeShoppingTrip (10, 10);
		shoppingList = new ShoppingList ();
	}

	void SpawnShopGrid(){
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				GameObject new_tile = Instantiate (tile, new Vector3 ((x * 0.1f) - 2.5f, (y * 0.1f) - 0.2f, 0), Quaternion.identity);
				tile_grid [x * height + y] = new_tile;
			}
		}
	}

	GameObject GetTile(int x, int y){
		return tile_grid [x * height + y];
	}

	// Update is called once per frame
	void Update () {
		
	}

	float GetDistance(Vector2 pos1, Vector2 pos2){
		return Vector2.Distance (pos1, pos2);
	}

	public void Initiate(ShoppingList sl){
		shoppingList = sl;
		SpawnShopGrid ();
		InitializeShoppingTrip (0, 0);
	}

	void InitializeShoppingTrip(int x, int y){
		GetTile (x, y).GetComponent<SpriteRenderer> ().color = Color.green;
		Vector2 current_position = my_position;
		sorted_shopping_list = new List<Product> ();

		while (shoppingList.products.Count > 0) {

			float min_dist = 1000;
			int next_index = 0;
			for (int i = 0; i < shoppingList.products.Count; i++) {
				float new_dist = GetDistance (my_position, new Vector2 (shoppingList.products[i].data.x, shoppingList.products[i].data.y));
				if (new_dist < min_dist) {
					min_dist = new_dist;
					next_index = i;
				}
			}

			sorted_shopping_list.Add (shoppingList.products [next_index]);
			shoppingList.products.RemoveAt (next_index);

		}

		for (int i = 0; i < sorted_shopping_list.Count; i++) {
			GetTile ((int)sorted_shopping_list [i].data.x, (int)sorted_shopping_list [i].data.y).GetComponent<SpriteRenderer>().color = Color.red;
		}

		//shoppingList.Sort (Compare);G
		DrawRoute();
		DrawPath ((int)my_position.x, (int)sorted_shopping_list [0].data.x, (int)my_position.y, (int)sorted_shopping_list [0].data.y, Color.green);
	}

	void DrawXPath(int x1, int x2, int y){
		int minX = x1;
		int maxX = x2;
		if (x2 < x1) {
			minX = x2;
			maxX = x1;
		}
		for (int x = minX + 1; x < maxX; x++) {
			GetTile (x, y).GetComponent<SpriteRenderer> ().color = Color.blue;
		}
	}
	void DrawPath(int x1, int x2, int y1, int y2, Color c){
		int current_x = x1; 
		int current_y = y1;
		int end_x = x2;
		int end_y = y2;
		if (Mathf.Abs (x1 - x2) > Mathf.Abs (y1 - y2)) {
			if (x2 < x1) {
				current_x = x2;
				end_x = x1;
				current_y = y2;
				end_y = y1;
			}
		} else {
			if (y2 < y1) {
				current_y = y2;
				current_x = x2;
				end_y = y1;
				end_x = x1;
			}
		}
			
		if (Mathf.Abs (x1 - x2) > Mathf.Abs (y1 - y2)) {
			while (current_x != end_x) {

				if (current_x < end_x) {
					current_x += 1;
				} else {
					current_x -= 1;
				}
				if (current_x != end_x || current_y != end_y) {
					GetTile (current_x, current_y).GetComponent<SpriteRenderer> ().color = c;
				}
			}
			while (current_y != end_y) {
				if (current_y < end_y) {
					current_y += 1;
				} else {
					current_y -= 1;
				}
				if (current_x != end_x || current_y != end_y) {
					GetTile (current_x, current_y).GetComponent<SpriteRenderer> ().color = c;
				}
			}
		}
		else {
			while (current_y != end_y) {
				if (current_y < end_y) {
					current_y += 1;
				} else {
					current_y -= 1;
				}
				if (current_x != end_x || current_y != end_y) {
					GetTile (current_x, current_y).GetComponent<SpriteRenderer> ().color = c;
				}
			}
			while (current_x != end_x) {
				if (current_x < end_x) {
					current_x += 1;
				} else {
					current_x -= 1;
				}
				if (current_x != end_x || current_y != end_y) {
					GetTile (current_x, current_y).GetComponent<SpriteRenderer> ().color = c;
				}
			}
		}
	}

	void DrawRoute(){
		for (int i = 0; i < sorted_shopping_list.Count-1; i++) {
			Product current_product = sorted_shopping_list [i];
			float x1 = sorted_shopping_list [i].data.x;
			float x2 = sorted_shopping_list [i + 1].data.x;
			float y1 = sorted_shopping_list [i].data.y;
			float y2 = sorted_shopping_list [i + 1].data.y;
			DrawPath ((int)x1, (int)x2, (int)y1, (int)y2, Color.blue);
		}
	}

	IEnumerator ShoppingListWork(){
		yield return null;
	}
}
