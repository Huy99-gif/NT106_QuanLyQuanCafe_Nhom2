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
            // Nếu chat chung thì vào phòng global
            if (string.IsNullOrEmpty(id2) || id2 == "Everyone")
            {
                return "room_global";
            }

            // Sắp xếp ID để đảm bảo: dù là (NV01, NV02) hay (NV02, NV01) 
            // thì kết quả trả về luôn là "chat_NV01_NV02"
            List<string> ids = new List<string> { id1, id2 };
            ids.Sort();

            return $"chat_{ids[0]}_{ids[1]}";
        }
    }
}
