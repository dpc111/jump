using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour {
    public static Dictionary<int, Player> Players = new Dictionary<int,Player>();
    public int CurPlayerId = 0;
    
	// Use this for initialization
	void Start () {
        Players.Clear();
        CurPlayerId = 0;
        if (CurPlayerId == 0)
        {
            return;
        }

            
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Add(Player player)
    {
        if (Players.ContainsKey(player.Id))
        {
            Debug.LogError("player mgr exist this player");
            return;
        }
        Players.Add(player.Id, player);
    }

    public static Player Get(int id)
    {
        Player player = Players[id];
        return player;
    }

    public bool IsSelf(int id)
    {
        if (id == CurPlayerId)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
