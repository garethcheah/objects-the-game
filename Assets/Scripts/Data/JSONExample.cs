using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SampleData sampleData = new SampleData();

        sampleData.name = "test";
        sampleData.score = 10.0f;

        string data = JsonUtility.ToJson(sampleData);

        string json = "{\n\t\"name\": \"Alice\", \n\t\"score\": 90.3\n}";
        SampleData sampleData2 = JsonUtility.FromJson<SampleData>(json);

        Debug.Log($"Deserialized {sampleData2.name} - Score: {sampleData2.score}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class SampleData
{
    public string name;
    public float score;
}
