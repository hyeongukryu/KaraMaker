using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaraMakerSheetTools
{
    static class EntityValidator
    {
        public static void Validate(this Entity entity, List<Entity> entities)
        {
            if (string.IsNullOrWhiteSpace(entity.Key))
            {
                throw new Exception("Key");
            }
            if (!string.IsNullOrWhiteSpace(entity.NextKey) &&
                !entities.Exists(e => e.Key == entity.NextKey))
            {
                throw new Exception("NextKey");
            }
            if (!string.IsNullOrWhiteSpace(entity.ParentKey) &&
                !entities.Exists(e => e.Key == entity.ParentKey))
            {
                throw new Exception("ParentKey");
            }
        }

        public static void Validate(this List<Entity> entities)
        {
            foreach (var e in entities)
            {
                e.Validate(entities);
            }

            var keys = from e in entities
                       select e.Key;

            if (entities.Count != keys.Distinct().Count())
            {
                throw new Exception("중복된 키가 있습니다.");
            }
        }
    }
}
