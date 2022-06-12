using UnityEngine.SceneManagement;

namespace Systems
{
    public class SceneLoader : SingletonMonoBehavior<SceneLoader>
    {
        #region Public methods

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        #endregion
    }
}