using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    /// <summary>
    /// Содержит параметры и логику загрузки игровых сцен
    /// </summary>
    class LoadManager:MonoBehaviour
    {
        private const int mainSceneIndex = 0;
        private const int gameSceneIndex = 1;
        private const int scoresSceneIndex = 2;

        /// <summary>
        /// Загрузить главное меню
        /// </summary>
        public void LoadMainScene()
        {
            SceneManager.LoadScene(mainSceneIndex);
        }
        /// <summary>
        /// Загрузить сцену с игрой
        /// </summary>
        public void LoadGameScene()
        {
            SceneManager.LoadScene(gameSceneIndex);
        }
        /// <summary>
        /// Загрузить сцену со счетеом
        /// </summary>
        public void LoadScoresScene()
        {
            SceneManager.LoadScene(scoresSceneIndex);
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        public void Quitgame()
        {
            Application.Quit();
        }


    }
}
