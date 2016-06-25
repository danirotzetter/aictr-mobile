using System;
using System.Collections.Generic;

namespace aictr.data
{
	/// <summary>
	/// Contains buffered data
	/// </summary>
	[Serializable]
	public class DataBuffer
	{
        // Keep track of the login credentials
        public String Username { get; set; }
        public String Password { get; set; }

        /// <summary>
        /// Gets or sets the grades.
        /// </summary>
        /// <value>The grades.</value>
        List<Grade> Grades{ get; set; }

		public DataBuffer ()
		{
		}


        /// <summary>
        /// Checks whether a user has set his credentials
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }



    }
}

