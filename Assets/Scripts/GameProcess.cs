using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    private float time;
    private bool isEndGame = false;
    [SerializeField] private Parameters parameters;
    [SerializeField] private Watcher watcher;
    [SerializeField] private Player player;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource seAudioSource;
    [SerializeField] private List<Animator>  animators;
    [SerializeField] private GameObject ResultWindow;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private AudioClip bombSE;
    private Player player2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
        player.IsMoveable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame) return;
        time += Time.deltaTime;
        if (watcher.WatchPlayerMove())
        {
            StartCoroutine("gameFail");
        }
        //Debug.Log("動きを確認"+watcher.WatchPlayerMove());

        if (player.Pos.x < -parameters.ClearLine || player.Pos.x > parameters.ClearLine)
        {
            StartCoroutine(nameof(gameClear));
        }
        if (player.Pos.x > parameters.Watcher2ShowLine)
        {
            
        }
    }

    private IEnumerator gameFail()
    {
        Debug.Log("gameFail");
        isEndGame = true;
        // bgmストップ
        audioSource.Pause();
        // ヒットストップ
        foreach (Animator animator in animators)
        {
            animator.speed = 0;
        }

        // 爆発の効果音
        seAudioSource.PlayOneShot(bombSE);
        yield return new WaitForSeconds(0.5f);
        // リザルト画面の表示
        resultText.text = "見つかってしまった…";
        ResultWindow.SetActive(true);
    }
    private IEnumerator gameClear()
    {
        isEndGame = true;
        

        yield return new WaitForSeconds(0.5f);
        // リザルト画面の表示
        resultText.text = "Clear!\nTime:"+time+"s";
        ResultWindow.SetActive(true);
    }
}