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
            UIManagerScript.Instance.ToggleLogin();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        void Awake()
        {
            // Get the singleton
            control = DataControl.Instance;

            RefreshLoginStatus();
        }


        /// <summary>
        /// Restore credentials if already set in the DataControl
        /// </summary>
        private void RefreshLoginStatus()
        {
            // If available, restore the already preset variables
            if (!string.IsNullOrEmpty(DataControl.Instance.DataBuffer.Username))
                username.text = DataControl.Instance.DataBuffer.Username;
            if (!string.IsNullOrEmpty(DataControl.Instance.DataBuffer.Password))
                password.text = DataControl.Instance.DataBuffer.Password;

            // Update the login status
            iconLoggedOut.enabled = !(iconLoggedIn.enabled = control.DataBuffer.IsLoggedIn());
        }



    }
}