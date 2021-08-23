using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractablesObjects.InteractablesObject{
    public class DoorOti : ObjectsToInteract
    {
        public void RestartGame(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
