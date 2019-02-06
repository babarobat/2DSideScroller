using UnityEngine;
using Zenject;
namespace Game
{
    public class GameController : MonoBehaviour
    {
        [Inject]
        private GameConfig _config;
        

        private void Awake()
        {

        }

       
        public void StartGame()
        {
            
            
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        private void PawnPlayer(Transform spawnPoint, PlayerController charecterPrefab)
        {
            var tmpChar = Instantiate(charecterPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
}
