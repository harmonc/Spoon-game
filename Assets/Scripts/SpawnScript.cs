using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject spawnObject;
    public int y;
    public Vector2 range;
    public float frequency;
    private float time;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > frequency) {
            time = 0;
            for (int i = 0; i < amount; i++)
            {
                GameObject newObject = Instantiate(spawnObject);
                newObject.transform.position = new Vector3(Random.Range(range.x, range.y), y, 0.0f);
            }
        }
    }
}
