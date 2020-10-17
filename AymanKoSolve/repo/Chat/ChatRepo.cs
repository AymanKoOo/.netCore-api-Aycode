using AymanKoSolve.Migrations;
using AymanKoSolve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AymanKoSolve.ModelViews.problem;
using AymanKoSolve.ModelViews.chat;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace AymanKoSolve.repo.Chat
{
    public class ChatRepo : IChatRepo
    {
        private readonly ApplicationDbContext _db; //const intialize at compile time , readonly intialize at runtime
        private readonly UserManager<ApplicationUser> _user;

        public ChatRepo(ApplicationDbContext db, UserManager<ApplicationUser> user)
        {
            _db = db;
            _user = user;
        }

       

        public async Task<Chatt> CreateRoom(string name,string id)
        {
            var chatt = new Chatt
            {
                Name = name,
                Type = ChatType.Room
            };

            chatt.Users.Add(new ChatUser
            {
               UserId = id
            });
         
            _db.Chat.Add(chatt);
            await _db.SaveChangesAsync();
            return chatt;
        }


        public async Task<ChatUser>  joinRoom(int roomID, string userId)
        {
            var ChatUser = new ChatUser
            {
                ChatId = roomID,
                UserId = userId
            };

            _db.ChatUser.Add(ChatUser);
            await _db.SaveChangesAsync();
            return ChatUser;
        }

      
        Task<Chatt> IChatRepo.GetChat(int id)
        {
            var chat = _db.Chat.Include(x=>x.Message).FirstOrDefaultAsync(x => x.Id == id);

            if (chat != null) return chat;
            return null;

        }


     
         async Task<Message> IChatRepo.CreateMessage(int chatId, string messsage)
         {
            var message = new Message
            {

                Name = "Default",
                Text = messsage,
                ChatId = chatId,
                Timestamp = DateTime.Now
            };
          
            var result = _db.Message.AddAsync(message);
            await _db.SaveChangesAsync();
            return message;
        }

        

    }
}
