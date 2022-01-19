using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace com.baltamstudios.stellardomination
{
    public class BattleUI : NetworkBehaviour
    {
        [SyncVar(hook = nameof(OnPlayerNameChange))]
        public string playerName;
        [SyncVar(hook = nameof(OnEnergyChange))]
        public int Energy;
        [SyncVar(hook = nameof(OnCrewChange))]
        public int Crew;

        [SerializeField]
        Text nameLabel;
        [SerializeField]
        Text energyTextField;
        [SerializeField]
        Text crewTextField;

        // Update is called once per frame


        public void OnPlayerNameChange(string _old, string _new)
        {
            nameLabel.text = _new;
        }
        public void OnEnergyChange(int _old, int _new)
        {
            energyTextField.text = _new.ToString();
        }

        public void OnCrewChange(int _old, int _new)
        {
            crewTextField.text = _new.ToString();
        }

    }
}