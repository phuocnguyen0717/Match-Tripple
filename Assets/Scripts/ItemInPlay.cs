using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInPlay : MonoBehaviour
{
    int collectionItemsCount;
    public void OnMouseDown()
    {
        collectionItemsCount = GameManager.Instance.collectionItems.Count;

        if (collectionItemsCount < 7)
        {
            // không nên sử dụng Destroy(gameobject) chỗ này vì sẽ ko thêm item 2d vào list collectionItems được
            gameObject.SetActive(false);
            GameManager.Instance.collectionItems.Add(gameObject);
            GameManager.Instance.itemsInPlay.Remove(gameObject);
            Grid.Instance.DisplayCollectedItem();
        }
    }
}
