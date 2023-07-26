using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] GameObject gameStageClear;
    int maxItemCount;
    int currentItemCount;
    bool getAllItems = false;
    public int MaxItemCount => maxItemCount;
    public int CurrentItemCount => currentItemCount;

    void Awake()
    {
        Time.timeScale = 1.0f;
        maxItemCount = GameObject.FindGameObjectsWithTag("Item").Length;
        currentItemCount = maxItemCount;
    }

    private void Update()
    {
        if (getAllItems == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }

    public void GetItem()
    {
        currentItemCount--;
        if (currentItemCount == 0)
        {
            getAllItems = true;
            StartCoroutine(ShowStageClearUI());
        }
    }

    IEnumerator ShowStageClearUI()
    {
        
        yield return new WaitForSeconds(1f);
        
        float blinkDuration = 3f;
        float blinkInterval = 0.3f;
        float elapsedTime = 0f;

        while (elapsedTime < blinkDuration)
        {
            gameStageClear.SetActive(!gameStageClear.activeSelf);
            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

       
        gameStageClear.SetActive(true);
        Time.timeScale = 1f;
    }

    void Die()
    {
        
    }
}