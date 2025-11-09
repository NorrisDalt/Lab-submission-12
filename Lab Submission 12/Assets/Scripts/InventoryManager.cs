using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private void Start()
    {
        // Populate inventory
        inventory.Add(new InventoryItem(101, "Sword", 100));
        inventory.Add(new InventoryItem(205, "Shield", 150));
        inventory.Add(new InventoryItem(150, "Potion", 50));
        inventory.Add(new InventoryItem(120, "Helmet", 75));

        // Linear search example
        InventoryItem foundByName = LinearSearchByName("Helmet");
        if (foundByName != null)
        {
            Debug.Log("Linear Search Found: " + foundByName.Name);
        }

        // Sort inventory by ID for binary search
        inventory.Sort((a, b) => a.ID.CompareTo(b.ID));

        // Binary search example
        InventoryItem foundByID = BinarySearchByID(120);
        if (foundByID != null)
        {
            Debug.Log("Binary Search Found: " + foundByID.Name);
        }

        QuickSortByValue(inventory, 0, inventory.Count - 1);

        // Print the sorted inventory to the console
        Debug.Log("=== Inventory Sorted by Value ===");
        foreach (InventoryItem item in inventory)
        {
            Debug.Log($"Name: {item.Name}, Value: {item.Value}");
        }
    }

    // Linear search method
    public InventoryItem LinearSearchByName(string itemName)
    {
        foreach (InventoryItem item in inventory)
        {
            if (item.Name == itemName)
                return item;
        }
        return null;
    }

    // Binary search method
    public InventoryItem BinarySearchByID(int id)
    {
        int left = 0;
        int right = inventory.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (inventory[mid].ID == id)
                return inventory[mid];
            else if (inventory[mid].ID < id)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;


    }

    //  QuickSort by Value
    public void QuickSortByValue(List<InventoryItem> list, int first, int last)
    {
        if (first < last)
        {
            int pivotIndex = Partition(list, first, last);
            QuickSortByValue(list, first, pivotIndex - 1);
            QuickSortByValue(list, pivotIndex + 1, last);
        }
    }

    // Helper: Partition method for QuickSort
    private int Partition(List<InventoryItem> list, int first, int last)
    {
        int pivot = list[last].Value;
        int i = first - 1;

        for (int j = first; j < last; j++)
        {
            if (list[j].Value < pivot)
            {
                i++;
                Swap(list, i, j);
            }
        }

        Swap(list, i + 1, last);
        return i + 1;
    }

    // Helper: Swap method
    private void Swap(List<InventoryItem> list, int a, int b)
    {
        InventoryItem temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
}
