using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace aictr.UI
{
    /// <summary>
    /// User interface manager script to deal with navigation and scene loading.
    /// </summary>
    public class UIManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Instance singleton
        /// </summary>
        public static UIManagerScript Manager { get; private set; }

        /// <summary>
        /// Reference to animators
        /// </summary>
        public Animator loginSlider;
        public Animator menuSlider;

        public enum Screen { HOME = 0, CAPTURE_GRADE = 1, STUDENTS_LIST = 2 };



        // Use this for initialization
        void Awake()
        {
            if (Manager == null)
            {
                DontDestroyOnLoad(gameObject);
                Manager = this;
                InitializeUi();

            }
            else
            {
                // Cannot use this control since the singleton is already created
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Perform some initialization tasks
        /// </summary>
        private void InitializeUi()
        {
            loginSlider.SetBool("isHidden", true);
            menuSlider.SetBool("isHidden", true);
        }

        /// <summary>
        /// Navigates to different screen.
        /// </summary>
        /// <param name="screen">Screen.</param>
        private void NavigateTo(Screen screen)
        {
            SceneManager.LoadScene((int)screen);
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