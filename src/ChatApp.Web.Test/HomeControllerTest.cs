using ChatApp.Domain.Models;
using ChatApp.Infra.RepositoryInterface;
using ChatApp.Web.Controllers;
using ChatApp.Web.Hubs;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ChatApp.Web.Test
{
    [TestClass]
    public class HomeControllerTest
    {

        private readonly HomeController _homeController;
        private readonly Mock<IChatRepository> _charRepoMock = new Mock<IChatRepository>();

        public HomeControllerTest()
        {
            _homeController = new HomeController(_charRepoMock.Object);
        }


        //[TestMethod]
        //public void index_OK()
        //{

        //    var user = "1";
        //    //var chats = _homeController.
            
            
            
        //    //string user = "1";
        //    //var mockRepo = new Mock<IChatRepository>();
        //    //var mockChat = new Mock<IQueryable<Domain.Models.Chat>>();

        //    //mockRepo.Setup(repo => repo.GetChats(It.IsAny<string>())
        //    //    //.Returns(mockChat.Object);
        //    //    .Throws(new System.Exception());
            
            
        //    //var controller = new HomeController(mockRepo.Object);
        //    //IActionResult result = controller.Index() as ViewResult;
            
        //    //Assert.IsNotNull(result);

            
        //}

        [TestMethod]
        public void HubsAreMockableViaDynamic()
        {
            bool sendCalled = false;
            var hub = new ChatHub();
            var mockClients = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = (Microsoft.AspNetCore.SignalR.IHubCallerClients)mockClients.Object;
            dynamic all = new ExpandoObject();
            all.broadcastMessage = new Action<string, string>((name, message) => {
                sendCalled = true;
            });
            mockClients.Setup(m => m.All).Returns((ExpandoObject)all);
            hub.JoinRoom("1");
            Assert.IsTrue(sendCalled);
        }
    }
}
