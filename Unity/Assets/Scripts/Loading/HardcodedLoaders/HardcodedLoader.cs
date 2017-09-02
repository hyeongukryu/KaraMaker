using System;
using Contents;

namespace Loading.HardcodedLoaders
{
    partial class HardcodedLoader : LoaderBase
    {
        public HardcodedLoader(Bundle bundle, GameConfiguration gameConfiguration) : base(bundle, gameConfiguration)
        {
        }

        private void AddEntity(Entity entity)
        {
            GameConfiguration.Entities.Add(entity);
        }

        public override void Load()
        {
            LoadStatuses();
            LoadOpening();
            LoadScheduleDialogs();
            LoadTalks();
        }
    }
}
