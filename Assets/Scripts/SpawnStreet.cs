using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStreet : MonoBehaviour
{
    public GameObject streetPrefab;
    public List<GameObject> buildingPrefabs;
    public List<GameObject> vehiclePrefabs;
    public List<GameObject> collectablePrefabs;


    private float[] lanes = { 6f, 3.6f, 1.18f, -1f };
    private int[,] lanePairs = { {0, 1}, {0, 2}, {0, 3}, { 1, 2 }, { 1, 3 }, { 2, 3 } };
    private bool isStarted = false;
    private float laneLength = 96f;
    private float splitterPoint = 2f;

    void Start() {
        CreateStreet(0f);
        isStarted = !isStarted;
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Street")) {
            CreateStreet(laneLength + other.transform.position.x);
            
        }
        
    }

    private void CreateStreet(float startPos) {
        Instantiate(streetPrefab, new Vector3(startPos, 0, 0), streetPrefab.transform.rotation);
        float step = 12f;
        float diff = 8f;
        for (int i = 0; i < 8; i++)
        {
            int r0 = Random.Range(0, buildingPrefabs.Count);
            int l0 = Random.Range(0, buildingPrefabs.Count);
            Instantiate(buildingPrefabs[r0], new Vector3(startPos + i * step, 0, 0), buildingPrefabs[r0].transform.rotation);
            Vector3 rot = buildingPrefabs[l0].transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            Instantiate(buildingPrefabs[l0], new Vector3(startPos + i * step + diff, 0, 5f), Quaternion.Euler(rot));
        }
        GenerateVehicles(startPos + ((!isStarted) ? step : 0f), startPos + laneLength);

    }

    private void GenerateVehicles(float startPos, float endPos)
    {
        float step = 12f;
        float y = 0.4f;
        float epsilon = 0.1f;
        float chance = 0.6f;
        

        for (float i = startPos + step; i < endPos; i += step) {
            if (Random.value > chance)
            {
                var pairID = Random.Range(0, 6);
                int c0 = Random.Range(0, vehiclePrefabs.Count);
                int c1 = Random.Range(0, vehiclePrefabs.Count);
                generateVehcile(vehiclePrefabs[c0], new Vector3(i + Random.Range(-1, 2), y, lanes[lanePairs[pairID, 0]]), (lanes[lanePairs[pairID, 0]] < splitterPoint));
                generateVehcile(vehiclePrefabs[c1], new Vector3(i + Random.Range(-1, 2), y, lanes[lanePairs[pairID, 1]]), (lanes[lanePairs[pairID, 1]] < splitterPoint));
                
                float cp = lanes[Random.Range(0, 3)];
                if (Mathf.Abs(cp - lanes[lanePairs[pairID, 0]]) > epsilon && Mathf.Abs(cp - lanes[lanePairs[pairID, 1]]) > epsilon)
                {
                    generateCollectable(i, cp);
                }

            }
            else {
                int c0 = Random.Range(0, vehiclePrefabs.Count);
                float lane = lanes[Random.Range(0, 3)];
                generateVehcile(vehiclePrefabs[c0], new Vector3(i + Random.Range(-1, 2), y, lane), (lane < splitterPoint));
                float cp = lanes[Random.Range(0, 3)];
                if (Mathf.Abs(cp - lane) >epsilon) {
                    generateCollectable(i, cp);
                }
            }
            
        }
        
    }

    private void generateCollectable(float startPos, float lane) {
        float y = 0.7f;
        int c = Random.Range(0, collectablePrefabs.Count);
        Instantiate(collectablePrefabs[c], new Vector3(startPos, y, lane), collectablePrefabs[c].transform.rotation);
    }

    private void generateVehcile(GameObject prefab, Vector3 position, bool isFrontDirection) {
        Vector3 rot = prefab.transform.rotation.eulerAngles;
        if (!isFrontDirection) rot = new Vector3(rot.x, rot.y + 180, rot.z);
        Instantiate(prefab, position, Quaternion.Euler(rot));
    }
}
