using UnityEngine;
using TMPro;

namespace FranArch
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ScoreText;
        [SerializeField] private TextMeshProUGUI CountText;

        public void SetScore(int score)
        {
            ScoreText.SetText("{0}/{1}", score, ((score / 10) + 1) * 10);
        }

        public void SetCount(int count)
        {
            CountText.SetText("{0}", count);
        }
    }
}
