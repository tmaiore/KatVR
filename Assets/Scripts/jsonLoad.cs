using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;

public class jsonLoad/* : MonoBehaviour*/
{
    // json file 
    

    [System.Serializable]
    public class Map
    {
        public mapData[] area;
    }

    [System.Serializable]
    public class mapData
    {
        public string shape;
        public string color;
        public float X;
        public float Y;
        public double width;
        public double heigth;
        public float angle;
    }
    public Map createJson(TextAsset jsonFile)
    {
        Map map;
        map = JsonUtility.FromJson<Map>("{\"area\":" + jsonFile.text + "}"); 
        //print(map.area[0].color);
        return map;
    }
   
}