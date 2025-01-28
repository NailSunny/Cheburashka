using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ��� ���������� �������


public class LifeManager : MonoBehaviour
{
    public GameObject[] lives; // ������ �������� ��� ������ (�����������)
    private int currentLives; // ������� ���������� ������
    //public Image warningVignette; // ������ �� ����������� ��������
    public GameObject warningVignetteObject;
    void Start()
    {
        currentLives = lives.Length; // ������������� ���������� ������ ������ ���������� �����������
        UpdateLivesUI();
        //warningVignette.enabled = false; // ��������� �������� �� ������

        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(false); // ��������� ������ ��������
        }
    }

    // ����� ��� ��������� �����
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; // ��������� �����
            UpdateLivesUI();
        }

        //// ���� ��� ����� ��������, ��������������� ��
        //if (currentLives <= 0)
        //{
        //    StartCoroutine(RestoreLives());
        //}
        // ���� ��� ����� ��������, ������������� ����
        if (currentLives <= 0)
        {
            RestartGame();
        }
    }

    // ����� ��� ���������� ����������� ������
    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currentLives)
                lives[i].SetActive(true); // �������� �������� �����
            else
                lives[i].SetActive(false); // ��������� ���������� �����
        }
        // ���������� ��������, ���� �������� ���� �����
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
    //    yield return new WaitForSeconds(0.5f); // �������� ����� ���������������
    //    currentLives = lives.Length; // ��������������� �����
    //    UpdateLivesUI();
    //}
    private void ShowWarningVignette()
    {
        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(true); // ���������� ������ ��������
        }
    }

    private void HideWarningVignette()
    {
        if (warningVignetteObject != null)
        {
            warningVignetteObject.SetActive(false); // ������������ ������ ��������
        }
    }

    // ���������� ����
    private void RestartGame()
    {
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
