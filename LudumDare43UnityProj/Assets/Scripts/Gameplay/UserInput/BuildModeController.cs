﻿using Assets.Scripts.Gameplay.Buildings;
using Assets.Scripts.Gameplay.World;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Assets.Scripts.Gameplay.UserInput
{
    class BuildModeController : MonoBehaviour
    {
        private bool isBuilding;

        private Building template;

        [SerializeField] private LayerMask layerMask;

        private Hologram hologram;

        public void StartBuilding(Building buildingTemplate)
        {
            isBuilding = true;
            template = buildingTemplate;

            hologram = Instantiate(template.ConstructionHologram);
        }

        public void CancelBuilding()
        {
            isBuilding = false;
            template = null;
            if (hologram != null)
            {
                Destroy(hologram.gameObject);
                hologram = null;
            }
        }

        public void Update()
        {
            if (!isBuilding) return;

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, float.MaxValue, layerMask);

            Tile tile = null;
            bool isValidPosition = false;
            if (hit)
            {
                tile = hitInfo.transform.parent.gameObject.GetComponent<Tile>();
                Debug.Assert(tile != null, "Tile object's collider should be its immediate child");
            }

            if (tile != null)
            {
                hologram.Enabled = true;

                // TODO: Account for the pivot of the building... Right now this happens to work cause the it positions based on teh center
                var holoPos = tile.transform.position;
                hologram.transform.position = holoPos;

                //hologram.IsValid = Util.CanBuildAt()
            }
            else
            {
                hologram.Enabled = false;
                hologram.IsValid = false;
            }
        }
    }
}
