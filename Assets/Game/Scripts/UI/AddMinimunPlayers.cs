using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMinimunPlayers : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(AddingPlayers);
        
	}
	private void AddingPlayers()
    {
        GameManager.Instance.PlayersToStart = 2;

    }
    // Update is called once per frame
    void Update () {
		
	}
}
