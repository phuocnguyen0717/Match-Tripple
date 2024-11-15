using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public ItemsManager itemsManager;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        itemsManager.GenerateRandomItem();
    }

    void Update()
    {

    }
}
