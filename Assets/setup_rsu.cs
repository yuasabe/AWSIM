using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class setup_rsu : MonoBehaviour
{
    public GameObject myPrefab;

    public TextAsset textJSON;

    [System.Serializable]
    public class Rsu {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class RsuList {
        public Rsu[] rsu;
    }

    public RsuList rsuList = new RsuList();

    public GameObject randomTrafficSimulator;
    public GameObject rsu1;
    // GameObject rsu_object;
    AWSIM.RandomTraffic.RandomTrafficSimulator rts;

    // Start is called before the first frame update
    void Start()
    {
        // rsuList = JsonUtility.FromJson<RsuList>(textJSON.text);

        Load();

        foreach (Rsu rsu in rsuList.rsu) {
            // rsu_object = Instantiate(myPrefab, new Vector3(rsu.x, rsu.y, rsu.z), Quaternion.identity);
            // GameObject rsu1 = GameObject.Find("AutowareSimulation/RSU 1");
            rsu1.transform.position = new Vector3(rsu.x, rsu.y, rsu.z);
        }

        // rts = randomTrafficSimulator.GetComponent<AWSIM.RandomTraffic.RandomTrafficSimulator>();
        // rts.egoVehicle = rsu_object.transform;

        // GameObject randomTrafficSimulatorObject = GameObject.Find("AutowareSimulation/Environment/Nishishinjuku RandomTraffic/RandomTrafficSimulator");
        // if (randomTrafficSimulatorObject != null)
        // {
            
        //     randomTrafficSimulatorObject.GetComponent("RandomTrafficSimulator").seed = 42;
        // }
        // else
        // {
        //     Debug.Log("Unable to find randomTrafficSimulatorObject in scene");
        // }
    }

    string GetPath() {
        string path = Path.Combine(Application.dataPath, "test.json");
        Debug.Log(path);
        return path;
    }

    void Load() {
        StreamReader reader = new StreamReader(GetPath());
        string jsonString = reader.ReadToEnd();
        reader.Close();
        JsonUtility.FromJsonOverwrite(jsonString, rsuList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
