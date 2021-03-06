﻿using System.Collections.Generic;
using Assets.Scripts.Gameplay.Buildings;
using Assets.Scripts.Gameplay.UserInput;
using Assets.Scripts.Gameplay.World;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        public static GameplayController instance { get; private set; }

        [SerializeField] private PlayerController playerController = null;
        [SerializeField] private PopulateWorld worldPopulator = null;
        [SerializeField] private Volcano volcano;

        [SerializeField]
        private YouWinController plugDialog;

        public Building SelectedBuilding { get; set; }

        public World.World World { get; private set; }

        public Resources.ResourceCollection CurrentResources;

        public int maxPopulation { get; set; }
        public Volcano VolcanoController { get { return volcano; } }
        public PlayerController PlayerController {  get { return playerController; } }

        public int PlugCount { get; set; }

        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }

        public void Start()
        {
            World = worldPopulator.World;
            volcano.BYFIREBEPURGED(World);
        }

        public void PlugVolcano()
        {
            CurrentResources.Stone -= 1000;
            PlugCount++;

            plugDialog.Show();
        }
    }
}
