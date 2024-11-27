using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace TF
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;
        [SerializeField] string gameOverSceneName = "MainMenu";
        void Update()
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime < 30)
                    timerText.color = Color.yellow;
            }
            else if (remainingTime < 0)
            { 
                remainingTime = 0;
                GameOver();
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        void GameOver()
        {
            // �����ڴ˴������κν�����Ϸ�Ĳ�����������ʾ������Ϣ�ȡ�
            // ��������Ϸ��������
            SceneManager.LoadScene(gameOverSceneName); // ���ݳ������Ƽ��ؽ�������
        }
    }
}