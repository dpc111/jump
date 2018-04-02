using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeMgr : MonoBehaviour {
    public static Dictionary<int, GameObject> StakePrefabs = new Dictionary<int, GameObject>();
    public static Dictionary<int, int> StakeLens = new Dictionary<int, int>(); 
    public static List<GameObject> Stakes = new List<GameObject>();
    public static int LastIndex = 1;
    public static int CurMinIndex = 1;
    public static int CurMaxIndex = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void AddPlan()
    {
        int size = StakePrefabs.Count;
        int rindex = Random.Range(1, size);
        GameObject rObject = StakePrefabs[rindex];

        size = StakeLens.Count;
        rindex = Random.Range(1, size);
        int len = StakeLens[rindex];

        GameObject lastStake = Stakes[Stakes.Count];
        StakePro stakePro = lastStake.GetComponent<StakePro>();
        LastIndex = stakePro.Index + 1;
        Vector3 pos = stakePro.Cen + new Vector3(0, len + stakePro.Len, 0);
        Quaternion rot = Quaternion.Euler(0f, 0f, 0f);

        GameObject newStake = Instantiate(rObject, pos, rot);
        StakePro newStakePro = newStake.GetComponent<StakePro>();
        newStakePro.Index = LastIndex;
        newStakePro.Len = len;
        newStakePro.Cen = pos;

        Stakes.Add(newStake);
    }

    public static void ReachStack(int index)
    {
        CurMaxIndex = index;
        CurMinIndex = index;
        while (Stakes.Count < CurMaxIndex + 3)
        {
            AddPlan();
        }

        while (Stakes.Count > 0)
        {
            GameObject stake = Stakes[1];
            StakePro stakePro = stake.GetComponent<StakePro>();
        }
    }
}
