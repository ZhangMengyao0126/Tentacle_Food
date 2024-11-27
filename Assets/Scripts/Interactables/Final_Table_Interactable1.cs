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
        [SerializeField] private string[] requiredTags; // ������õ���Ϸ�ʲ���Tag
        [SerializeField] private int currentCount = 0; // ��ǰ�ѷ��õ���ȷ�ʲ�����
        [SerializeField] private List<GameObject> placedObjects = new List<GameObject>(); // �ѷ��õ���Ϸ�ʲ��б�

        [SerializeField] string gameSuccessSceneName = "MainMenu";

        public override void OnInteract()
        {
            base.OnInteract();
            // ����Ƿ�������������
            if (currentCount == requiredTags.Length)
            {
                GameSuccess();
            }
            else
            {
                Debug.Log("δ��������������");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // �����ײ���Ƿ�Ϊ������ʲ�
            foreach (var tag in requiredTags)
            {
                if (other.CompareTag(tag))
                {
                    currentCount++;
                    placedObjects.Add(other.gameObject); // ����Ʒ��������б�
                    Debug.Log($"��������ȷ����Ʒ: {other.name}");
                    return; // ��ֹ�ظ����
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // �����Ʒ�뿪�˴������򣬽���Ӽ������б����Ƴ�
            if (placedObjects.Contains(other.gameObject))
            {
                currentCount--;
                placedObjects.Remove(other.gameObject);
                Debug.Log($"��Ʒ�뿪��������: {other.name}");
            }
        }

        void GameSuccess()
        {
            // �����ڴ˴������κν�����Ϸ�Ĳ�����������ʾ������Ϣ�ȡ�
            // ��������Ϸ��������
            SceneManager.LoadScene(gameSuccessSceneName); // ���ݳ������Ƽ��ؽ�������
        }
    }
}

