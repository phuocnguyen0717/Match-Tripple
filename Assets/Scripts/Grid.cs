using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    public static Grid Instance { get; set; }
    public List<Sprite> collectionItemsSprite = new();
    public List<Mesh> itemsMeshInPlay = new();
    public Transform rowParent;
    public GameObject itemCollectorPrefab;
    public GameObject cell;
    private List<GameObject> collectedItems;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void DisplayCollectedItem()
    {
        collectedItems = GameManager.Instance.collectionItems;

        collectedItems.Sort((x, y) => string.Compare(x.name, y.name));

        UpdateGridWithItems();
        RemoveMatchingItems();
    }
    private void RemoveMatchingItems()
    {
        Dictionary<string, List<GameObject>> itemGroups = GroupItemsByName();

        RemoveMatchingItemsFromGroup(itemGroups);
    }
    private void UpdateGridWithItems()
    {
        for (int i = 0; i < collectedItems.Count; i++)
        {
            // duyệt qua các cell để thêm các item
            Transform cell = rowParent.GetChild(i);

            foreach (Transform child in cell)
            {
                Destroy(child.gameObject);
            }
            //Tạo các item theo itemPrefab
            GameObject itemObject = Instantiate(itemCollectorPrefab, cell);
            Image itemImage = itemObject.GetComponent<Image>();
            itemObject.name = collectedItems[i].name;

            SetItemSpriteFromCollection(itemImage);
        }
        ClearUnusedCells();
    }
    private void SetItemSpriteFromCollection(Image itemImage)
    {
        foreach (Sprite item in collectionItemsSprite)
        {
            if (itemImage.name.Equals(item.name))
            {
                if (itemImage == null) return;

                itemImage.sprite = item;
            }
        }
    }

    private void RemoveMatchingItemsFromGroup(Dictionary<string, List<GameObject>> itemGroups)
    {
        foreach (var group in itemGroups)
        {
            if (group.Value.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject itemToRemove = group.Value[i];
                    collectedItems.Remove(itemToRemove);
                    Destroy(itemToRemove);
                }
                UpdateGridWithItems();
                break;
            }
        }
    }
    private Dictionary<string, List<GameObject>> GroupItemsByName()
    {
        Dictionary<string, List<GameObject>> itemGroups = new Dictionary<string, List<GameObject>>();

        foreach (GameObject item in collectedItems)
        {
            if (!itemGroups.ContainsKey(item.name))
            {
                itemGroups[item.name] = new List<GameObject>();
            }
            itemGroups[item.name].Add(item);
        }

        return itemGroups;
    }

    private void ClearUnusedCells()
    {
        for (int i = collectedItems.Count; i < rowParent.childCount; i++)
        {
            Transform cell = rowParent.GetChild(i);

            // Xóa toàn bộ các child trong cell
            foreach (Transform child in cell)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
