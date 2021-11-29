using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Controllers.Test;
using WebApp.Interfaces;
using WebDemo.ViewModels;
using Xunit;

namespace Tests
{
    [Collection("ActorProjectCollection")]
    public class StudentsControllerTest
    {
        
        [Fact]
        [Trait("TestType", "CreateTest")]
        public async Task CreateStudentTest()
        {
            await  StudentControllerTestHook.CreateStudentTestHook();
        }
        [Fact]
        [Trait("TestType", "GetAllTest")]
        public async Task GetAllStudentsTest()
        {
            await StudentControllerTestHook.GetAllTestHook();
        }

        [Fact]
        [Trait("TestType", "SearchTest")]
        public async Task SearchStudentTest()
        {
            await StudentControllerTestHook.SearchStudentTestHook();
        }

        [Fact]
        [Trait("TestType", "UpdateTest")]
        public async Task UpdateStudentTest()
        {
            await StudentControllerTestHook.UpdateStudentTestHook();
        }

        [Fact]
        [Trait("TestType", "DeleteTest")]
        public async Task DeleteStudentTest()
        {
            await StudentControllerTestHook.DeleteStudentTestHook();
        }
    }
}
