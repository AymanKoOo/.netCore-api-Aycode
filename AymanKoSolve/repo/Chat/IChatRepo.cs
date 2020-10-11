using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.problem;
using AymanKoSolve.ModelViews.chat;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.repo.Chat
{
    public interface IChatRepo
    {
        Task<Chatt> CreateRoom(string name, string id);

        Task<ChatUser> joinRoom(int roomId,string userId);

        Task<Chatt> GetChat(int chatId);

        Task<Message> CreateMessage(int chatId,string messsage);



    }
}
