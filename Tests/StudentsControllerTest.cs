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
        [Trait("TestType", "CreateStudentTest")]
        public async Task CreateStudentTest()
        {
            await  StudentControllerTestHook.CreateStudentTestHook();
        }
        [Fact]
        [Trait("TestType", "GetAllStudentsTest")]
        public async Task GetAllStudentsTest()
        {
            await StudentControllerTestHook.GetAllTestHook();
        }

        [Fact]
        [Trait("TestType", "SearchStudentTest")]
        public async Task SearchStudentTest()
        {
            await StudentControllerTestHook.SearchStudentTestHook();
        }

        [Fact]
        [Trait("TestType", "UpdateStudentTest")]
        public async Task UpdateStudentTest()
        {
            await StudentControllerTestHook.UpdateStudentTestHook();
        }

        [Fact]
        [Trait("TestType", "DeleteStudentTest")]
        public async Task DeleteStudentTest()
        {
            await StudentControllerTestHook.DeleteStudentTestHook();
        }
    }
}
