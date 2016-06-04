using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using UnityEngine;

namespace aictr.data
{
    /// <summary>
    /// Class to deal with data synchronization
    /// </summary>
    public class TransmissionController : MonoBehaviour
    {
        #region constants
        private static string contentTypeXformJson="application/x-www-form-urlencoded";
        #endregion

        /// <summary>
        /// Synchronize data with the online server
        /// </summary>
        /// <param name="dataBuffer"></param>
        internal void SynchronizeData(Settings settings, DataBuffer dataBuffer)
        {
            string url = settings.ServerUrl;
            POST("http://jsonplaceholder.typicode.com/posts", "title: 'foo',body: 'bar',userId: 1", TreatSyncResult);
            GET("http://jsonplaceholder.typicode.com/posts", TreatSyncResult);
        }

        /// <summary>
        /// Deal with the reply from a synchronization task
        /// </summary>
        /// <param name="reply"></param>
        private void TreatSyncResult(string data, Exception error)
        {
            if (error == null)
            {
                // Success
                Debug.Log("Successful reply: " + data);
            }
            else
            {
                // Error
                Debug.Log("Error: " + error);
            }
            
        }



        /// <summary>
        /// Execute a GET request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="onComplete"></param>
        /// <returns></returns>
        private void GET(string url, Action<string, Exception> onComplete)
        {

            WebClient cli = new WebClient();
            cli.DownloadStringCompleted += new DownloadStringCompletedEventHandler((sender, eventArgs) => onComplete(eventArgs.Result, eventArgs.Error));
            cli.Headers[HttpRequestHeader.ContentType] = contentTypeXformJson;
            cli.DownloadStringAsync(new Uri(url), WebRequestMethods.Http.Get);
        }

        /// <summary>
        /// Execute a POST request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <param name="onComplete"></param>
        /// <returns></returns>
        private void POST(string url, string payload, Action<string, Exception> onComplete)
        {

            WebClient cli = new WebClient();
            cli.UploadStringCompleted += new UploadStringCompletedEventHandler((sender, eventArgs)=>onComplete(eventArgs.Result, eventArgs.Error));
            cli.Headers[HttpRequestHeader.ContentType] = contentTypeXformJson;
            cli.UploadStringAsync(new Uri(url), WebRequestMethods.Http.Post, payload);
            
        }
        
         
          
    }
}