using System;
using System.Collections.Generic;
using Contents;

namespace Game
{
    interface IStatusService
    {
        IStatus Get(string key);
        int GetFixedValue(string key);
        double GetRealValue(string key);
        int GetAgeBracket();
        void Commit(Entity entity);
        List<Tuple<string, int>> GetEffectiveChanges(Entity entity);
        string GetChangesDigest(Entity entity);
    }
}
