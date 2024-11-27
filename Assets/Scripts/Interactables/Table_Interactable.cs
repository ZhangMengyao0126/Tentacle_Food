using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TF
{
    public class TableInteractable : InteractableBase
    {
        [Header("Required Ingredients")]
        [SerializeField] private string[] requiredTags; // 必须放置的游戏资产的Tag
        [SerializeField] private GameObject newAssetPrefab; // 替代生成的新游戏资产
        [SerializeField] private Transform spawnPoint; // 新游戏资产生成的位置

        [SerializeField] private int currentCount = 0; // 当前已放置的正确资产数量
        [SerializeField] private List<GameObject> placedObjects = new List<GameObject>(); // 已放置的游戏资产列表

        public override void OnInteract()
        {
            base.OnInteract();
            // 检查是否满足生成条件
            if (currentCount == requiredTags.Length)
            {
                // 删除所有放置的物品
                foreach (var obj in placedObjects)
                {
                    Destroy(obj);
                }
                placedObjects.Clear();

                // 生成新物品
                GenerateNewAsset();

                // 重置计数
                currentCount = 0;
            }
            else
            {
                Debug.Log("未满足生成条件！");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // 检查碰撞物是否为所需的资产
            foreach (var tag in requiredTags)
            {
                if (other.CompareTag(tag))
                {
                    currentCount++;
                    placedObjects.Add(other.gameObject); // 将物品加入放置列表
                    Debug.Log($"放置了正确的物品: {other.name}");
                    return; // 防止重复检测
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // 如果物品离开了触发区域，将其从计数和列表中移除
            if (placedObjects.Contains(other.gameObject))
            {
                currentCount--;
                placedObjects.Remove(other.gameObject);
                Debug.Log($"物品离开触发区域: {other.name}");
            }
        }

        private void GenerateNewAsset()
        {
            if (newAssetPrefab != null && spawnPoint != null)
            {
                Instantiate(newAssetPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("生成了新物品！");
            }
        }
    }
}

