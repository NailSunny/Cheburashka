using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ �� ��������� �������
    private int score = 0; // ���������� ��� �������� �����
    public TextMeshProUGUI bestScoreText; // ������ �� ����� ������� �����
    private int bestScore = 0; // ������ ����

    void Start()
    {
        // ��������� ������ ���� �� PlayerPrefs (���� ��� ���, ����� 0)
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        UpdateBestScoreText();
    }
    // ����� ��� ���������� �����
    public void AddScore(int points)
    {
        score += points; // ����������� ����
        UpdateScoreText(); // ��������� �����
        // ���������, ����� �� ������ ����
        if (score > bestScore)
        {
            bestScore = score; // ��������� ������ ����
            PlayerPrefs.SetInt("BestScore", bestScore); // ��������� ������ ����
            UpdateBestScoreText();
        }
    }

    // ��������� ����� � UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    // ��������� ����� ������� �����
    private void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + bestScore;
    }
}
