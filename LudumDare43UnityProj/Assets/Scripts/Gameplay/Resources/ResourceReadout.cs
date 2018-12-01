﻿using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.Resources
{
    public class ResourceReadout : MonoBehaviour
    {
        [SerializeField] private GameplayController controller;

        [SerializeField] private Text foodText;
        [SerializeField] private Text populationText;
        [SerializeField] private Text woodText;
        [SerializeField] private Text stoneText;

        void Start()
        {
            UpdateDisplay();
        }

        void Update()
        {
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            foodText.text = controller.currentResources.Food.ToString();
            populationText.text = controller.currentResources.Population.ToString() + " / " + controller.maxPopulation.ToString();
            woodText.text = controller.currentResources.Wood.ToString();
            stoneText.text = controller.currentResources.Stone.ToString();
        }
    }
}