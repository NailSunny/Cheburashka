using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Для управления сценами


public class LifeManager : MonoBehaviour
{
    public GameObject[] lives; // Массив объектов для жизней (изображений)
    private int currentLives; // Текущее количество жизней
    //public Image warningVignette; // Ссылка на изображение виньетки
    public GameObject warningVignetteObject;
    void Start()
    {
        currentLives = lives.Length; // Устанавливаем количество жизней равным количеству изображений
        UpdateLivesUI();
        //warningVignette.enabled = false; // Отключаем виньетку на старте

        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(false); // Отключаем объект виньетки
        }
    }

    // Метод для отнимания жизни
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; // Уменьшаем жизни
            UpdateLivesUI();
        }

        //// Если все жизни потеряны, восстанавливаем их
        //if (currentLives <= 0)
        //{
        //    StartCoroutine(RestoreLives());
        //}
        // Если все жизни потеряны, перезапускаем игру
        if (currentLives <= 0)
        {
            RestartGame();
        }
    }

    // Метод для обновления отображения жизней
    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currentLives)
                lives[i].SetActive(true); // Включаем активные жизни
            else
                lives[i].SetActive(false); // Выключаем потерянные жизни
        }
        // Показываем виньетку, если осталась одна жизнь
        if (currentLives == 1)
        {
            ShowWarningVignette();
        }
        else
        {
            HideWarningVignette();
        }
    }

    //private IEnumerator RestoreLives()
    //{
    //    yield return new WaitForSeconds(0.5f); // Задержка перед восстановлением
    //    currentLives = lives.Length; // Восстанавливаем жизни
    //    UpdateLivesUI();
    //}
    private void ShowWarningVignette()
    {
        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(true); // Активируем объект виньетки
        }
    }

    private void HideWarningVignette()
    {
        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(false); // Деактивируем объект виньетки
        }
    }

    // Перезапуск игры
    private void RestartGame()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
