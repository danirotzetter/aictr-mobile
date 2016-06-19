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
        /// Reference to animators
        /// </summary>
        public Animator loginSlider;
        public Animator menuSlider;

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

        /// <summary>
        /// Navigation identificators
        /// </summary>
        public enum Screen { HOME = 0, CAPTURE_GRADE = 1, STUDENTS_LIST = 2 };



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
            // Set default states of UI elements
            loginSlider.SetBool("isHidden", true);
            menuSlider.SetBool("isHidden", true);

            if (!isInitialized)
            {
                DontDestroyOnLoad(header);
                DontDestroyOnLoad(background);
                isInitialized = true;
            }
        }

        /// <summary>
        /// Navigates to different screen.
        /// </summary>
        /// <param name="screen">Screen.</param>
        private void NavigateTo(Screen screen)
        {
            SceneManager.LoadScene((int)screen);

            // Close menu if open
            if (!menuSlider.GetBool("isHidden"))
            {
                menuSlider.SetBool("isHidden", true);
            }
        }
        public void NavigateToCapture() { NavigateTo(Screen.CAPTURE_GRADE); }
        public void NavigateToStudentsList() { NavigateTo(Screen.STUDENTS_LIST); }
        public void NavigateToHome() { NavigateTo(Screen.HOME); }


        /// <summary>
        /// Open login screen
        /// </summary>
        public void ToggleLogin()
        {
            bool isHidden = loginSlider.GetBool("isHidden");
            loginSlider.SetBool("isHidden", !isHidden);
        }
        /// <summary>
        /// Open login screen
        /// </summary>
        public void ToggleMenu()
        {
            bool isHidden = menuSlider.GetBool("isHidden");
            menuSlider.SetBool("isHidden", !isHidden);
        }
    }
}