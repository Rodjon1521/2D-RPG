using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HpBar : MonoBehaviour
    {
        public Image ImageCurrent;

        public void SetValue(int current, int max)
        {
            ImageCurrent.fillAmount = (float)current / (float)max;
        }
    }
}