using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeMgr : MonoBehaviour {
    public static Dictionary<int, GameObject> StakePrefabs = new Dictionary<int, GameObject>();
    public static Dictionary<int, int> StakeLens = new Dictionary<int, int>(); 
    public static List<GameObject> Stakes = new List<GameObject>();
    public static int CurMinIndex = 1;
    public static int CurMaxIndex = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddPlan()
    {
        int size = StakePrefabs.Count;
        int rindex = Random.Range(1, size);
        GameObject rObject = StakePrefabs[rindex];
        size = StakeLens.Count;
        rindex = Random.Range(1, size);
        int lastStakeIndex = Stakes.Count;
        GameObject lastStake = Stakes[lastStakeIndex];
        Stack stack = lastStake.GetComponent<Stack>();
    }
}
