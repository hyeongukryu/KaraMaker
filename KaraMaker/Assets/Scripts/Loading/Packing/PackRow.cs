using System;

namespace Loading.Packing
{
    class PackRow
    {
        public JSONObject JsonObject { get; }
        public JSONObject Columns { get; }

        public PackRow(JSONObject jsonObject)
        {
            JsonObject = jsonObject;
            if (!jsonObject.HasField("c"))
            {
                throw new Exception("번들 데이터 구성이 잘못되었습니다.");
            }
            Columns = jsonObject["c"];
            if (!Columns.IsArray)
            {
                throw new Exception("번들 데이터 구성에 문제가 있습니다.");
            }
        }

        public string this[int index]
        {
            get
            {
                if (Columns[index].HasField("v"))
                {
                    return Columns[index].str;
                }
                return null;
            }
        }
    }
}
