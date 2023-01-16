using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using UC17.Controllers;
using UC17.Interfaces;
using UC17.Models;
using UC17.Repertories;
using UC17.ViewModels;

namespace TestIntegracao
{
    public class LoginContrTest
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            //Arrange - Preparação 
            var repositoryEspelhado = new Mock<UsuarioRepository>

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email@gmail.com";
            dadosUsuario.senha = "1234";
            //Act - Ação 

            var resultado = controller.Login(dadosUsuario);

            //Assert - Verificação

            Assert.IsType<UnauthorizedObjectResult>(resultado);


        }


        [Fact]

        public void LoginController_Retornar_Token()
        {
            //Arrange

            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = "email@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.Id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email@gmail.com";
            dadosUsuario.senha = "1234";

            var controller = new LoginController(repositoryEspelhado.Object);
            string issuervalido = "cahpter.webapi";

            //Act

            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);
            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);


            //Assert
            Assert.Equal(issuervalido, tokenJwt.Issuer);

        }
    }
}