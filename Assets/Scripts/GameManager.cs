using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BrickBreak.Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager GameManagerInstance;
        public GameObject GameStartUI;
        public long Score = 0;
        public Text ScoreText;
        internal bool isGameStarted;
        internal long NumberOfCollisions;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameStarted)
            {
                if (Input.anyKeyDown)
                {
                    isGameStarted = true;
                    GameStartUI.SetActive(false);
                    ScoreText.gameObject.SetActive(true);
                }
            }
        }

        void Awake()
        {
            GameManagerInstance = this;
            Score = 0;
            NumberOfCollisions = 0;
            isGameStarted = false;
        }

        public void Restart()
        {
            SceneManager.LoadScene("Game");
            Score = 0;
        }

        public void IncreaseScore()
        {
            Score += NumberOfCollisions;
            ScoreText.text = Score.ToString();
        }
    }
}

