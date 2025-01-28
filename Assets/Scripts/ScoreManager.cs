using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Ссылка на текстовый элемент
    private int score = 0; // Переменная для хранения очков
    public TextMeshProUGUI bestScoreText; // Ссылка на текст лучшего счёта
    private int bestScore = 0; // Лучший счёт

    void Start()
    {
        // Загружаем лучший счёт из PlayerPrefs (если его нет, будет 0)
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        UpdateBestScoreText();
    }
    // Метод для увеличения счёта
    public void AddScore(int points)
    {
        score += points; // Увеличиваем очки
        UpdateScoreText(); // Обновляем текст
        // Проверяем, побит ли лучший счёт
        if (score > bestScore)
        {
            bestScore = score; // Обновляем лучший счёт
            PlayerPrefs.SetInt("BestScore", bestScore); // Сохраняем лучший счёт
            UpdateBestScoreText();
        }
    }

    // Обновляем текст в UI
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    // Обновляем текст лучшего счёта
    private void UpdateBestScoreText()
    {
        bestScoreText.text = "Best Score: " + bestScore;
    }
}
