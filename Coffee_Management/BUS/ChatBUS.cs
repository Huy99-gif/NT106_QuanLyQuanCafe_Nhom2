using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChatBUS
    {
        private readonly ChatDAL _chatDal = new ChatDAL();

        public async Task SaveMessage(string roomId, ChatMessageDTO msg)
        {
            // Lấy token đang lưu trong GlobalSession sau khi đăng nhập thành công
            string? token = GlobalSession.Token;
            await _chatDal.SaveMessageAsync(roomId, msg, token);
        }

        public async Task<List<ChatMessageDTO>> GetHistory(string roomId)
        {
            string? token = GlobalSession.Token;
            return await _chatDal.GetHistoryAsync(roomId, token);
        }

        public string GetRoomId(string id1, string id2)
        {
            if (string.IsNullOrEmpty(id2) || id2 == "Everyone")
            {
                return "room_global";
            }

            // Ví dụ: Sếp là "nv001", Nhân viên là "nv002"
            // Dù Sếp mở chat hay Nhân viên mở chat, kết quả luôn là "chat_nv001_nv002"
            List<string> ids = new List<string> { id1, id2 };
            ids.Sort();

            return $"chat_{ids[0]}_{ids[1]}";
        }
    }
}
