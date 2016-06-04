using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace aictr.data
{

    public class DataControl : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// The control keeping the data. Singleton.
        /// </summary>
        public static DataControl Control { get; private set; }
        /// <summary>
        /// Gets the data buffer file path.
        /// </summary>
        /// <value>The data buffer file path.</value>
        private static String DataBufferFilePath { get { return Application.persistentDataPath + "/dataBuffer.dat"; } }
        /// <summary>
        /// Data buffer that contains offline data
        /// </summary>
        /// <value>The data buffer.</value>
        public DataBuffer DataBuffer { get; private set; }
        /// <summary>
        /// Gets the settings file path
        /// </summary>
        private static String SettingsFilePath { get { return Application.persistentDataPath + "/settings.xml"; } }
        public Settings Settings { get; private set; }

        [SerializeField]
        private TransmissionController transmissionController;
        #endregion

        // Use this for initialization
        void Awake()
        {
            if (Control == null)
            {
                // Singleton not yet created
                // Make sure the object remains persisted
                DontDestroyOnLoad(gameObject);

                Control = this;

                // Load settings
                Settings = LoadSettings(SettingsFilePath);

                // Load data
                DataBuffer = LoadDataBuffer(DataBufferFilePath);



            }
            else
            {
                // Cannot use this control since the singleton is already created
                Destroy(gameObject);
            }
        }

        #region Data Storage
        /// <summary>
        /// Store settings
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="settingsFilePath"></param>
        public void SaveSettings(Settings settings, string settingsFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream stream = new FileStream(settingsFilePath, FileMode.Create))
            {
                serializer.Serialize(stream, settings);
            }
        }
        /// <summary>
        /// Load settings
        /// </summary>
        /// <param name="settingsFilePath"></param>
        /// <returns></returns>
        public Settings LoadSettings(string settingsFilePath)
        {
            if (!File.Exists(settingsFilePath))
            {
                // File does not exist yet: create empty one
                Settings settings = new Settings();
                SaveSettings(settings, settingsFilePath);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream stream = new FileStream(settingsFilePath, FileMode.Open))
            {
                Settings settings = serializer.Deserialize(stream) as Settings;
                return settings;
            }
        }

        /// <summary>
        /// Store buffered data to a file.
        /// </summary>
        /// <param name="dataBuffer"></param>
        /// <param name="filePath"></param>
        public void SaveDataBuffer(DataBuffer dataBuffer, string filePath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Create(filePath))
            {
                bf.Serialize(fs, dataBuffer);
            }
        }

        /// <summary>
        /// Load this buffered data.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataBuffer LoadDataBuffer(string filePath)
        {
            if (!File.Exists(DataBufferFilePath))
            {
                // File does not exist yet: create empty one
                DataBuffer dataBuffer = new DataBuffer();
                SaveDataBuffer(dataBuffer, filePath);
            }

            // Load buffered data
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = File.Open(DataBufferFilePath, FileMode.Open))
            {
                return (DataBuffer)bf.Deserialize(fs);
            }
        }


        /// <summary>
        /// Sync the data with the server
        /// </summary>
        public void SynchronizeWithServer()
        {                                                                        
            transmissionController.SynchronizeData(Settings, DataBuffer);
        }
        #endregion


    }
}