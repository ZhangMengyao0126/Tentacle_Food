using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TF
{
    public class FinalTableInteractable : InteractableBase
    {
        [Header("Required Ingredients")]
        [SerializeField] private string[] requiredTags; // 必须放置的游戏资产的Tag
        [SerializeField] private int currentCount = 0; // 当前已放置的正确资产数量
        [SerializeField] private List<GameObject> placedObjects = new List<GameObject>(); // 已放置的游戏资产列表

        [SerializeField] string gameSuccessSceneName = "MainMenu";

        public override void OnInteract()
        {
            base.OnInteract();
            // 检查是否满足生成条件
            if (currentCount == requiredTags.Length)
            {
                GameSuccess();
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

        void GameSuccess()
        {
            // 可以在此处进行任何结束游戏的操作，例如显示结束信息等。
            // 最后加载游戏结束画面
            SceneManager.LoadScene(gameSuccessSceneName); // 根据场景名称加载结束场景
        }
    }
}

