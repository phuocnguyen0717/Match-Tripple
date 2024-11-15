using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public List<GameObject> items;
    private float boundX = 15.0f;
    private float boundY = 14.0f;
    public Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-boundX, boundX);
        float spawnPosY = Random.Range(-boundY, boundY);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPos;
    }
    public Quaternion GenerateRandomRotation()
    {
        float spawnRotationX = Random.Range(0, 180);
        float spawnRotationY = Random.Range(0, 180);
        Quaternion spawnRotation = Quaternion.Euler(spawnRotationX, spawnRotationY, 0);
        return spawnRotation;
    }
    public void GenerateRandomItem()
    {
        for (int i = 0; i < 30; i++)
        {
            int indexItem = Random.Range(0, 25);
            Instantiate(items[indexItem], GenerateRandomPosition(), GenerateRandomRotation());
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
    }
}
