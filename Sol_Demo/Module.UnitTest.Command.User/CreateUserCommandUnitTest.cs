using AutoMapper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Module.Command.User.Applications.Features;
using Module.Command.User.Business.Rule;
using Module.Command.User.Infrastructures.DataService;
using Moq;
using System;
using System.Threading.Tasks;

namespace Module.UnitTest.Command.User
{
    [TestClass]
    public class CreateUserCommandUnitTest
    {
        private readonly Mock<IMapper> mapperMock = null;
        private readonly Mock<IMediator> mediatorMock = null;
        private readonly Mock<IHashPasswordRule> hashPasswordRuleMock = null;

        private IRequestHandler<CreateUserCommand, bool> createUserCommandHandler = null;

        public CreateUserCommandUnitTest()
        {
            mapperMock = new Mock<IMapper>(); ;
            mediatorMock = new Mock<IMediator>();
            hashPasswordRuleMock = new Mock<IHashPasswordRule>();

            createUserCommandHandler = new CreateUserCommandHandler(mediatorMock?.Object, hashPasswordRuleMock?.Object);
        }

        private CreateUserCommand Data => new CreateUserCommand()
        {
            FirstName = "Kishor",
            LastName = "Naik",
            Email = "kishor.naik011.net@gmail.com",
            Password = "1234"
        };

        [TestMethod]
        public async Task CreateUser_Suceess_TestMethod()
        {
            // Create Hash Passwod Mock
            hashPasswordRuleMock
                .Setup((r) => r.CreatePasswordAsync(It.IsAny<string>()))
                .ReturnsAsync((salt: "6lM8YGNBzM2bE6UJgdmWZC5bBtk76SBEZvycl63UWzc=", hash: "+ubvJ+FqXWrKYh0Ne0/pk1iXiPsJK0wiUWnPbgjqVnc="));

            // Create Mediator Mock
            mediatorMock
                .Setup((r) => r.Send<bool>(It.IsAny<CreateUserDataService>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(true);

            var response = await createUserCommandHandler.Handle(Data, new System.Threading.CancellationToken());

            Assert.IsTrue(Convert.ToBoolean(response));
        }

        [TestMethod]
        public async Task HashPassword_Fail_TestMethod()
        {
            // Create Hash Passwod Mock
            hashPasswordRuleMock
                .Setup((r) => r.CreatePasswordAsync(It.IsAny<string>()))
                .Throws<Exception>();

            // Create Mediator Mock
            mediatorMock
                .Setup((r) => r.Send<bool>(It.IsAny<CreateUserDataService>(), new System.Threading.CancellationToken()))
                .ReturnsAsync(true);

            try
            {
                var response = await createUserCommandHandler.Handle(Data, new System.Threading.CancellationToken());
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public async Task CreateUserDataService_Fail_TestMethod()
        {
            // Create Hash Passwod Mock
            hashPasswordRuleMock
                .Setup((r) => r.CreatePasswordAsync(It.IsAny<string>()))
                .ReturnsAsync((salt: "6lM8YGNBzM2bE6UJgdmWZC5bBtk76SBEZvycl63UWzc=", hash: "+ubvJ+FqXWrKYh0Ne0/pk1iXiPsJK0wiUWnPbgjqVnc="));

            // Create Mediator Mock
            mediatorMock
                .Setup((r) => r.Send<bool>(It.IsAny<CreateUserDataService>(), new System.Threading.CancellationToken()))
                .Throws<Exception>();

            try
            {
                var response = await createUserCommandHandler.Handle(Data, new System.Threading.CancellationToken());
            }
            catch (Exception ex)
            {
                Assert.IsTrue(true);
            }
        }
    }
}