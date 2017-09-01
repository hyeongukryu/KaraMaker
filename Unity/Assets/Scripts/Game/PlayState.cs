using System;
using System.Collections.Generic;
using Contents;
using UnityEngine;

namespace Game
{
    class PlayState
    {
        private Entity _activeEntity;

        public int Year { get; set; }
        public int Month { get; set; }
        public int Date { get; set; }
        public int Day { get; set; } // Mon 1, Sun 7

        public string BackgroundKey { get; set; }
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
                BackgroundKey = null;
            }
            BackgroundKey = image;
        }

        public DateTime CurrentEntityActivated { get; set; } = DateTime.Now;
        public TimeSpan CurrentEntityAirtime => DateTime.Now - CurrentEntityActivated;

        public List<IStatus> Statuses { get; set; } = new List<IStatus>();
        public int Gold { get; set; }        
    }
}
