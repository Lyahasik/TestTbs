using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Client.UI.Gameplay.Hud
{
    public class SkillButton : Button
    {
        [SerializeField] private GameObject recoveryObject;
        [SerializeField] private TMP_Text recoveryValueText;
        [SerializeField] private Image recoveryFill;

        public void SetRecovery(in int recovery, int maxRecovery = 0)
        {
            var recoveryActive = recovery > 0;

            interactable = !recoveryActive;
            recoveryObject.SetActive(recoveryActive);
            
            if (recoveryActive)
            {
                recoveryValueText.text = recovery.ToString();
                recoveryFill.fillAmount = (float)recovery / maxRecovery;
            }
        }
    }
}