using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingSequencePanel : MonoBehaviour {
	public GameObject tile;
	int width = 50;
	int height = 50;
	int start_x = 49;
	int start_y = 49;
	GameObject[] tile_grid;// = new GameObject[shop_width * shop_height];
	ShoppingList shoppingList;

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
		List<Product> sorted_shopping_list = new List<Product> ();

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
	}

	IEnumerator ShoppingListWork(){
		yield return null;
	}
}
