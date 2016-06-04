using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace aictr.data
{

	public class DataControl : MonoBehaviour
	{
        // Keep track of the login credentials
        public String Username { get; set; }
        public String Password { get; set; }


        /// <summary>
        /// Gets the data buffer file path.
        /// </summary>
        /// <value>The data buffer file path.</value>
        private static String DataBufferFilePath{ get { return Application.persistentDataPath + "/bufferedData/grades.dat"; } }


		/// <summary>
		/// The control keeping the data. Singleton.
		/// </summary>
		public static DataControl Control { get; private set; }

	
		/// <summary>
		/// Data buffer
		/// </summary>
		/// <value>The data buffer.</value>
		public DataBuffer DataBuffer{ get; private set; }

		// Use this for initialization
		void Awake ()
		{
			if (Control == null) {
				// Singleton not yet created
				// Make sure the object remains persisted
				DontDestroyOnLoad (gameObject);

				Control = this;
				DataBuffer = new DataBuffer ();
			} else {
				// Cannot use this control since the singleton is already created
				Destroy (gameObject);
			}
		}


		/// <summary>
		/// Store buffered data to a file.
		/// </summary>
		public void Save ()
		{
			BinaryFormatter bf = new BinaryFormatter ();
			using (FileStream fs = File.Create(DataBufferFilePath)) {
				bf.Serialize (fs, DataBuffer);
			}
		}

		/// <summary>
		/// Load this buffered data.
		/// </summary>
		public void Load(){
			if (File.Exists (DataBufferFilePath)) {
				// Load buffered data
				BinaryFormatter bf = new BinaryFormatter();
				using (FileStream fs = File.Open (DataBufferFilePath, FileMode.Open)) {
					
					DataBuffer = (DataBuffer)bf.Deserialize (fs);
				}
			}
		}

	}
}