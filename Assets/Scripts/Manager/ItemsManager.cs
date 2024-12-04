using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    private float boundX = 300.0f;
    private float boundY = 200.0f;
    public GameObject itemInPlay;
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
    public void GenerateItemsInPlay(int numberOfItemsInPlay)
    {
        GameManager.Instance.itemsInPlay.Clear();

        const int instancesPerItem = 3;
        int itemCount = Grid.Instance.itemsMeshInPlay.Count;

        if (itemCount == 0)
        {
            Debug.Log("Item list is empty");
            return;
        }

        for (int i = 0; i < numberOfItemsInPlay; i++)
        {
            int indexItem = Random.Range(0, itemCount);
            for (int j = 0; j < instancesPerItem; j++)
            {
                GameObject newItem = Instantiate(itemInPlay.gameObject,
                GenerateRandomPosition(), GenerateRandomRotation());

                MeshFilter itemMeshFilter = newItem.GetComponent<MeshFilter>();
                if (itemMeshFilter != null)
                {
                    itemMeshFilter.mesh = Grid.Instance.itemsMeshInPlay[indexItem];
                }
                itemMeshFilter.name = Grid.Instance.itemsMeshInPlay[indexItem].name;

                GameManager.Instance.itemsInPlay.Add(newItem);
            }
        }
    }
}
