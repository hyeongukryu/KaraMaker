using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contents;
using UnityEngine;

namespace Game
{
    class StatusService : IStatusService
    {
        public PlayState PlayState { get; }

        public StatusService(PlayState playState)
        {
            PlayState = playState;
        }

        public IStatus Get(string key)
        {
            var status = (from s in PlayState.Statuses
                          where s.Entity.Key == key
                          select s).FirstOrDefault();
            if (status == null)
            {
                Debug.Log("Unknown Status " + key);
            }
            return status;
        }

        public int GetFixedValue(string key) => Get(key).Value;
        public double GetRealValue(string key) => Get(key).Value * GameConfiguration.Root.FixedToReal;

        public int GetAgeBracket()
        {
            var age = Get("Age").Value;
            if (age >= 18) return 18;
            if (age >= 15) return 15;
            return 12;
        }

        public void Commit(Entity e)
        {
            var changes = GetEffectiveChanges(e);
            foreach (var change in changes)
            {
                var status = Get(change.Item1) as IWritableStatus;
                status.Value += change.Item2;
            }
        }

        public List<Tuple<string, int>> GetEffectiveChanges(Entity e)
        {
            var result = new List<Tuple<string, int>>();
            if (e.ChangeKeys != null)
            {
                var changes = e.ChangeKeys.Select(
                    (key, index) => Tuple.Create(key, e.ChangeAmounts[index]));
                result.AddRange(changes);
            }
            if (e.GoldChanges != null)
            {
                if (e.IsTalk)
                {
                    result.Add(Tuple.Create("Gold", e.GoldChanges.First()));
                }
            }
            return result;
        }

        public string GetChangesDigest(Entity e)
        {
            var changes = GetEffectiveChanges(e);
            var builder = new StringBuilder();
            foreach (var change in changes)
            {
                var key = change.Item1;
                var amount = change.Item2;

                if (amount == 0)
                {
                    continue;
                }

                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append(Get(key).Entity.DisplayName);
                builder.Append(" ");
                builder.Append(amount > 0 ? "+" : "");
                builder.Append((amount * GameConfiguration.Root.FixedToReal).ToString("F1"));
            }
            return builder.ToString();
        }
    }
}
