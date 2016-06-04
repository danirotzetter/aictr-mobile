using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using aictr.data;

public class LoginScript : MonoBehaviour {

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
        
        control.Username = username.text;
        control.Password = password.text;
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
        if(!string.IsNullOrEmpty(DataControl.Control.Username))
        username.text = DataControl.Control.Username;
        if (!string.IsNullOrEmpty(DataControl.Control.Password))
            password.text = DataControl.Control.Password;

        // Update the login status
        iconLoggedOut.enabled = ! (iconLoggedIn.enabled = IsLoggedIn());
    }



    /// <summary>
    /// Checks whether a user has set his credentials
    /// </summary>
    /// <returns></returns>
    public bool IsLoggedIn()
    {
        return control!=null && !string.IsNullOrEmpty(control.Username) && !string.IsNullOrEmpty(control.Password);
    }
}
