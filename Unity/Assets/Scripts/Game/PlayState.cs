using System;
using System.Collections.Generic;
using Contents;
using UnityEngine;

namespace Game
{
    class PlayState
    {
        private Entity _activeEntity;

        public DateTime BeginWalltime { get; set; }
        
        public int Year { get; set; }
        public int Month { get; set; }
        public int Date { get; set; }
        public int Day { get; set; } // Mon 1, Sun 7
        public int Epoch { get; set; }
        public long EpochHash { get; set; }

        public string Route { get; set; }
        public string BackgroundImage { get; set; }

        public string CurrentDressImage { get; set; }
        public string CurrentFaceImage { get; set; }
        public string CurrentBodyImage { get; set; }

        public bool TalkedToday { get; set; }
        
        public List<Entity> PendingEntities { get; set; } = new List<Entity>();

        public Entity ActiveEntity
        {
            get { return _activeEntity; }
            set
            {
                CurrentEntityActivated = DateTime.Now;
                _activeEntity = value;
                Update();
            }
        }

        private void Update()
        {
            if (_activeEntity?.ChangeBackgroundImage == null)
            {
                return;
            }
            var image = _activeEntity.ChangeBackgroundImage;
            if (image == "")
            {
                BackgroundImage = null;
            }
            BackgroundImage = image;
        }

        public DateTime CurrentEntityActivated { get; set; } = DateTime.Now;
        public TimeSpan CurrentEntityAirtime => DateTime.Now - CurrentEntityActivated;

        public List<IStatus> Statuses { get; set; } = new List<IStatus>();
    }
}
