using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using aictr.data;

namespace aictr.UI
{
    public class LoginScript : MonoBehaviour
    {

        [SerializeField]
        private Text username;
        [SerializeField]
        private Text password;
        [SerializeField]
        private Image iconLoggedIn;
        [SerializeField]
        private Image iconLoggedOut;
        private DataControl control;

        /// <summary>
        /// Stores credentials
        /// </summary>
        public void SaveLogin()
        {

            control.DataBuffer.Username = username.text;
            control.DataBuffer.Password = password.text;
            RefreshLoginStatus();

            // Hide the login form
            UIManagerScript.Manager.ToggleLogin();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        void Awake()
        {
            // Get the singleton
            control = DataControl.Control;

            RefreshLoginStatus();
        }


        /// <summary>
        /// Restore credentials if already set in the DataControl
        /// </summary>
        private void RefreshLoginStatus()
        {
            // If available, restore the already preset variables
            if (!string.IsNullOrEmpty(DataControl.Control.DataBuffer.Username))
                username.text = DataControl.Control.DataBuffer.Username;
            if (!string.IsNullOrEmpty(DataControl.Control.DataBuffer.Password))
                password.text = DataControl.Control.DataBuffer.Password;

            // Update the login status
            iconLoggedOut.enabled = !(iconLoggedIn.enabled = IsLoggedIn());
        }



        /// <summary>
        /// Checks whether a user has set his credentials
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return control != null && !string.IsNullOrEmpty(control.DataBuffer.Username) && !string.IsNullOrEmpty(control.DataBuffer.Password);
        }
    }
}