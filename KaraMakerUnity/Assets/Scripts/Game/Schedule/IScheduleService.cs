using System.Collections.Generic;
using Contents;

namespace Game.Schedule
{
    interface IScheduleService
    {
        List<Entity> BuildEntity(Entity schedule, int length);
        int GoldChanges(Entity schedule);
    }
}
