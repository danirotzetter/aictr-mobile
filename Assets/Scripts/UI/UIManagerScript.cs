using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace aictr.UI
{
    /// <summary>
    /// User interface manager script to deal with navigation and scene loading.
    /// </summary>
    public class UIManagerScript : Singleton<UIManagerScript>
    {


        /// <summary>
        /// References to essential objects
        /// </summary>
        [SerializeField]
        private Canvas header;
        [SerializeField]
        private Canvas background;


        /// <summary>
        /// Keep track of initialization to prevent duplicates
        /// </summary>
        private static bool isInitialized = false;



        // Use this for initialization
        void Awake()
        {
            // Perform general initialization tasks
            InitializeUi();
        }

        /// <summary>
        /// Perform some initialization tasks
        /// </summary>
        private void InitializeUi()
        {

            if (!isInitialized)
            {
                DontDestroyOnLoad(header);
                DontDestroyOnLoad(background);
                DontDestroyOnLoad(gameObject); // Should be handled by Singleton Instance access, but maybe the Instance property has not yet been called
                isInitialized = true;
            }
            else
            {
                Destroy(header.gameObject);
                Destroy(background.gameObject);
                Destroy(gameObject);
            }
        }


        /// <summary>
        /// Exit the application, thereby performing cleanup tasks
        /// </summary>
        /// <param name="shutDown">Optional parameter to force executing an application quit. If not set or if set to FALSE, then only the cleanup tasks are executed.</param>
        public void QuitApplication(bool shutDown=false)
        {
            if (shutDown)
            {
            Application.Quit();
            }
        }
        
    }
}