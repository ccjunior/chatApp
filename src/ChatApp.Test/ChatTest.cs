using ChatApp.Infra.Context;
using ChatApp.Infra.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ChatApp.Test
{
    [TestClass]
    public class ChatTest
    {

        private ChatRepository chatRepository;
        private Mock<AppDbContext> context = new Mock<AppDbContext>();
        private Mock<ChatApp.Domain.Models.Chat> Ch;

        public ChatTest()
        {
            chatRepository = new ChatRepository(context.Object);
            Ch = new Mock<ChatApp.Domain.Models.Chat>();
            
        }
        
        [TestMethod]
        public void CreateMessage_Ok()
        {
            int chatid = 1;
            string message = "enviando mensagem";
            string userid = "2";

            var result = chatRepository.CreateMessage(chatid, message, userid);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreatePrivateRom_Ok()
        {
            string root = "2";
            string target = "544";
            

            var result = chatRepository.CreatePrivateRoom(root, target);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateRom_Ok()
        {
            string name = "carlos";
            string user = "141";

            context.Object.Add<Ch>
            
            var result = chatRepository.CreateRoom(name,user);
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void GetChat_Ok()
        //{
        //    int id = 1;

        //    var result = chatRepository.GetChat(id);
        //    Assert.IsNotNull(result);
        //}


        [TestMethod]
        public void GetChats_Ok()
        {
            string user = "1";

            //chatRepository.ad
            
            var result = chatRepository.GetChats(user);
            Assert.AreEqual(result);
        }
    }
}
