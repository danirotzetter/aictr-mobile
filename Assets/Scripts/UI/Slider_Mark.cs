using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace aictr.UI
{
    public class Slider_Mark : MonoBehaviour
    {
        public Text Grade;

        public void onSliderChanged(float f)
        {
            Grade.text = (Mathf.Round(f) / 2).ToString();
        }
    }
}