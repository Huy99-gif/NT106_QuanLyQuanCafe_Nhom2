using System;
using Newtonsoft.Json;

namespace DTO
{
    public class TinNhanChatDTO
    {
        [JsonProperty("nguoi_gui_id")] // Newtonsoft (ChatDAL) + đúng schema Firebase
        public string? SenderId { get; set; }

        [JsonProperty("noi_dung")]
        public string? Message { get; set; }

        [JsonProperty("thoi_gian")]
        public long Timestamp { get; set; }

        [JsonProperty("loai_tin_nhan")]
        public string? MessageType { get; set; } = "text";
    }

    public class ChatMessageDTO : TinNhanChatDTO
    {
    }
}
    