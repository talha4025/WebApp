using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Interfaces;
using Xunit;
using WebDemo.Models.Context;
using WebDemo.ViewModels;
using Microsoft.Data.Sqlite;
using WebDemo.Services;
using System.Threading;

namespace WebApp.Controllers.Test
{
    public static class StudentControllerTestHook
    {


        public static async Task CreateStudentTestHook()
        {
            StudentsViewModel student = new StudentsViewModel
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            //create student controller with mock service
            StudentsController studentsController = new StudentsController(new StudentsServiceMock());

            //Create a demo student entry in database
            StudentsViewModel students = await studentsController.Post(student);


            Assert.NotNull(students);
            Assert.Equal(student.FirstName, students.FirstName);
            Assert.Equal(student.LastName, students.LastName);
            Assert.Equal(student.Address, students.Address);
            Assert.Equal(student.ContactInfo, students.ContactInfo);
            Assert.Equal(student.CGPA, students.CGPA);
            Assert.Equal(student.Department, students.Department);
            Assert.Equal(student.Gender, students.Gender);
            Assert.True(students is StudentsViewModel);
        }

        public static async Task DeleteStudentTestHook()
        {
            StudentsViewModel student = new StudentsViewModel
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            //create student controller with mock service
            StudentsController studentsController = new StudentsController(new StudentsServiceMock());

            //Create a demo student entry in database
            StudentsViewModel getStudent = await studentsController.Post(student);

            //Delete demo entry created in previous step
            string studentUpdated = await studentsController.Delete(getStudent.Id);
            string actual = $"Student with ID: {getStudent.Id} and Name: {getStudent.FirstName +" "+ getStudent.LastName} Deleted from Records";
            Assert.Equal(studentUpdated,actual);
        }

        public static async Task UpdateStudentTestHook()
        {
            StudentsViewModel student = new StudentsViewModel
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            //create student controller with mock service
            StudentsController studentsController = new StudentsController(new StudentsServiceMock());

            //Create a demo student entry in database
            StudentsViewModel getStudent = await studentsController.Post(student);

            student.FirstName = "Alii";
            student.Id = getStudent.Id;

            //Update demo entry created in previous step
            string studentUpdated = await studentsController.Put(student);
            string actual = $"Student with ID: {student.Id} Updated in Database Records";
            Assert.Equal(studentUpdated, actual);
        }

        public static async Task SearchStudentTestHook()
        {
            StudentsViewModel student = new StudentsViewModel
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            //create student controller with mock service
            StudentsController studentsController = new StudentsController(new StudentsServiceMock());

            //Create a demo student entry in database
            StudentsViewModel students = await studentsController.Post(student);

            //Search demo entry created in previous step
            StudentsViewModel searchedStudent = await studentsController.Search(1);

            Assert.NotNull(searchedStudent);
            Assert.Equal(searchedStudent.FirstName, students.FirstName);
            Assert.Equal(searchedStudent.LastName, students.LastName);
            Assert.Equal(searchedStudent.Address, students.Address);
            Assert.Equal(searchedStudent.ContactInfo, students.ContactInfo);
            Assert.Equal(searchedStudent.CGPA, students.CGPA);
            Assert.Equal(searchedStudent.Department, students.Department);
            Assert.Equal(searchedStudent.Gender, students.Gender);
            Assert.True(students is StudentsViewModel);
        }

        public static async Task GetAllTestHook()
        {
            StudentsViewModel student = new StudentsViewModel
            {
                FirstName = "Ali",
                LastName = "Malik",
                Address = "Islamabad",
                ContactInfo = "2342342423434",
                Department = "CS",
                Gender = "Male",
                CGPA = 0
            };

            //create student controller with mock service
            StudentsController studentsController = new StudentsController(new StudentsServiceMock());

            //Create a demo student entry in database
            StudentsViewModel students = await studentsController.Post(student);

            //Get demo entry created in previous step
            IEnumerable<StudentsViewModel> allStudents = await studentsController.Get();
            Assert.NotEmpty(allStudents);
            Assert.Equal(allStudents.First().FirstName, students.FirstName);
            Assert.Equal(allStudents.First().LastName, students.LastName);
            Assert.Equal(allStudents.First().Address, students.Address);
            Assert.Equal(allStudents.First().ContactInfo, students.ContactInfo);
            Assert.Equal(allStudents.First().CGPA, students.CGPA);
            Assert.Equal(allStudents.First().Department, students.Department);
            Assert.Equal(allStudents.First().Gender, students.Gender);
            Assert.True(allStudents.First() is StudentsViewModel);
        }

    }
}
