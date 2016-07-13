using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace aictr.UI
{
    /// <summary>
    /// Controls the status of the menu
    /// </summary>
    public class MenuScript : Singleton<MenuScript>
    {
        /// <summary>
        /// Reference to animators
        /// </summary>
        [SerializeField]
        private Animator menuSlider;
        [SerializeField]
        private Button home;
        [SerializeField]
        private Button captureGrades;
        [SerializeField]
        private Button students;
        [SerializeField]
        private Button login;
        [SerializeField]
        private Button quit;


        /// <summary>
        /// Navigation identificators
        /// </summary>
        public enum Screen { HOME = 0, CAPTURE_GRADE = 1, STUDENTS_LIST = 2 };

        void Awake()
        {
            // By default: not logged in, thus enable the login menu item
            SetLoginMenuItem(true);

            // Set default states of UI elements
            menuSlider.SetBool("isHidden", true);
        }



        /// <summary>
        /// Open login screen
        /// </summary>
        public void ToggleMenu()
        {
            bool isHidden = menuSlider.GetBool("isHidden");
            menuSlider.SetBool("isHidden", !isHidden);
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
        public void NavigateToLogin() { NavigateTo(Screen.HOME); LoginScript.Instance.ToggleLogin(true); }
        public void NavigateToLogout() { UIManagerScript.Instance.QuitApplication(); }


        /// <summary>
        /// Adjust the menu such that either only the login or all other items are visible
        /// </summary>
        /// <param name="doOnlyShowLoginItem"></param>
        public void SetLoginMenuItem(bool doOnlyShowLoginItem)
        {
            home.gameObject.SetActive(!doOnlyShowLoginItem);
            captureGrades.gameObject.SetActive(!doOnlyShowLoginItem);
            students.gameObject.SetActive(!doOnlyShowLoginItem);
            login.gameObject.SetActive(doOnlyShowLoginItem);
        }


    }
}
