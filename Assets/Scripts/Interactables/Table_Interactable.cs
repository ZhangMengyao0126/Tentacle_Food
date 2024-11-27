using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace TF
{
    public class TableInteractable : InteractableBase
    {
        [Header("Required Ingredients")]
        [SerializeField] private string[] requiredTags; // ������õ���Ϸ�ʲ���Tag
        [SerializeField] private GameObject newAssetPrefab; // ������ɵ�����Ϸ�ʲ�
        [SerializeField] private Transform spawnPoint; // ����Ϸ�ʲ����ɵ�λ��

        [SerializeField] private int currentCount = 0; // ��ǰ�ѷ��õ���ȷ�ʲ�����
        [SerializeField] private List<GameObject> placedObjects = new List<GameObject>(); // �ѷ��õ���Ϸ�ʲ��б�

        public override void OnInteract()
        {
            base.OnInteract();
            // ����Ƿ�������������
            if (currentCount == requiredTags.Length)
            {
                // ɾ�����з��õ���Ʒ
                foreach (var obj in placedObjects)
                {
                    Destroy(obj);
                }
                placedObjects.Clear();

                // ��������Ʒ
                GenerateNewAsset();

                // ���ü���
                currentCount = 0;
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

        private void GenerateNewAsset()
        {
            if (newAssetPrefab != null && spawnPoint != null)
            {
                Instantiate(newAssetPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("����������Ʒ��");
            }
        }
    }
}

