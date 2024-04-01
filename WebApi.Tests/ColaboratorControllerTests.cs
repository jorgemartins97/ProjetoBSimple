using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using WebApi.Controllers;
using Domain;
 
namespace WebApi.Tests
{
    public class ColaboratorControllerTests
    {
        // Utilitário para criar o contexto de banco de dados em memória
        private ColaboratorContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ColaboratorContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar um GUID para garantir um nome de banco de dados único
                .Options;
 
            var context = new ColaboratorContext(options);
 
            // Verifica se a tabela está vazia antes de adicionar novos dados
            if (!context.Colaborator.Any())
            {
                context.Colaborator.AddRange(GetFakeEmployeeList());
                context.SaveChanges();
            }
 
            return context;
        }
 
 
        // criar lista de colaboradores falsos
        private static List<Colaborator> GetFakeEmployeeList()
        {
            return new List<Colaborator>()
            {
                new Colaborator("John Doe", "J.D@gmail.com") { Id = 1 },
                new Colaborator("Mark Luther", "M.L@gmail.com") { Id = 2 },
            };
        }
 
        [Fact]
        public async Task GetColaborators_ReturnsAllColaborators()
        {
            using var context = GetContextWithData();
            var controller = new ColaboratorController(context);
            //act
            var result = await controller.GetColaborator();
 
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Colaborator>>>(result);
            var returnValue = Assert.IsType<List<Colaborator>>(actionResult.Value);
            Assert.Equal(2, returnValue.Count); 
        }
 
        [Fact]
        public async Task GetColaborator_ReturnsColaborator_WhenColaboratorExists()
        {
            using var context = GetContextWithData();
            var controller = new ColaboratorController(context);
 
            var result = await controller.GetColaborator(1);
 
            var actionResult = Assert.IsType<ActionResult<Colaborator>>(result);
            var colaborator = Assert.IsType<Colaborator>(actionResult.Value);
            Assert.Equal("John Doe", colaborator._strName);
        }
 
        [Fact]
        public async Task PutColaborator_ReturnsBadRequest_WhenIdMismatch()
        {
            using var context = GetContextWithData();
            var controller = new ColaboratorController(context);
 
            var result = await controller.PutColaborator(3, new Colaborator { _strName = "ola", _strEmail = "Mismatch" });
 
            Assert.IsType<BadRequestResult>(result);
        }
 
        [Fact]
        public async Task PostColaborator_CreatesNewColaborator()
        {
            // arrange
            using var context = GetContextWithData();
            var controller = new ColaboratorController(context);
            var newColaborator = new Colaborator("New Colab", "N.Colab@email.com");
 
            // act
            var result = await controller.PostColaborator(newColaborator);
 
            // assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result); 
            var returnValue = Assert.IsType<Colaborator>(actionResult.Value);
            Assert.Equal("New Colab", returnValue._strName); 
            Assert.True(context.Colaborator.Any(c => c._strName == "New Colab")); 
        }
 
 
 
        [Fact]
        public async Task DeleteColaborator_DeletesColaborator_WhenColaboratorExists()
        {
            using var context = GetContextWithData();
            var controller = new ColaboratorController(context);
            var existingId = 1;
 
            var result = await controller.DeleteColaborator(existingId);
 
            Assert.IsType<NoContentResult>(result);
            Assert.False(context.Colaborator.Any(c => c.Id == existingId));
        }
 
 
    }
}
 