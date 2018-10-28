using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public static List<Coin> coins = new List<Coin>();
    
	// Use this for initialization
	void Awake () {
        coins.Add(this);
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (!player)
            return;

        player.score++;
        player.Respawn();

        var newCoin = coins[Random.Range(0, coins.Count-1)];
        if (newCoin != this)
        {
            gameObject.SetActive(false);
            newCoin.gameObject.SetActive(true);
        }
    }
}
