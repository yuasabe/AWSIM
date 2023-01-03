using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class setup_objects : MonoBehaviour
{

    public GameObject objPrefab;

    [System.Serializable]
    public class ObjectPos {
        public float x;
        public float y;
        public float z;
    }

     [System.Serializable]
    public class ObjectRot {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    [System.Serializable]
    public class Object {
        public string name;
        public ObjectPos pos;
        public ObjectRot rot;
    }

    [System.Serializable]
    public class ObjectsList {
        public Object[] objects;
    }

    public ObjectsList objectsList = new ObjectsList();

    GameObject new_obj;

    // Start is called before the first frame update
    void Start()
    {

        Load();

        foreach (Object obj in objectsList.objects) {
            new_obj = Instantiate(objPrefab, new Vector3(obj.pos.x, obj.pos.y, obj.pos.z), new Quaternion(obj.rot.x, obj.rot.y, obj.rot.z, obj.rot.w));
            // GameObject rsu1 = GameObject.Find("AutowareSimulation/RSU 1");
            // rsu1.transform.position = new Vector3(rsu.x, rsu.y, rsu.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GetPath() {
        string path = Path.Combine(Application.dataPath, "objects.json");
        Debug.Log(path);
        return path;
    }

    void Load() {
        StreamReader reader = new StreamReader(GetPath());
        string jsonString = reader.ReadToEnd();
        reader.Close();
        JsonUtility.FromJsonOverwrite(jsonString, objectsList);
    }
}
