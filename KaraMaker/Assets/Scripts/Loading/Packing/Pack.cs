using System;

namespace Loading.Packing
{
    class Pack
    {
        public JSONObject JsonObject { get; }
        public JSONObject Rows { get; }

        public Pack(JSONObject jsonObject)
        {
            JsonObject = jsonObject;
            if (!jsonObject.HasField("table") || !jsonObject["table"].HasField("rows"))
            {
                throw new Exception("번들 내부 구성이 잘못되었습니다.");
            }
            Rows = jsonObject["table"]["rows"];
        }

        public int Length => Rows.Count;

        public PackRow this[int index] => new PackRow(Rows[index]);
    }
}
