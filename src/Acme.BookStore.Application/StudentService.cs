using Acme.BookStore.Dto;
using Acme.BookStore.Entity;
using Acme.BookStore.MessageHandler;
using Acme.BookStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class StudentService : BookStoreAppService
    {
        private readonly IRepository<Student, Guid> _studentRepo;
        private readonly StudentDomainService _studentDomainService;
        public StudentService(IRepository<Student, Guid> studentRepo, StudentDomainService studentDomainService)
        {
           _studentRepo = studentRepo;
            _studentDomainService = studentDomainService;

        }

        public async Task<object> PostAddStudent(StudentDto dto)
        {
            var result = await _studentDomainService.saveStudent(dto: dto);
            return result;
        }

        public async Task<object> GetStudent(string query)
        {
            var name = (await _studentRepo.GetQueryableAsync()).Where(x => query.Contains(x.StudentName)).ToList();
            return Message.SucessWithData("Student get sucessfully", name);
     
        }
    }
}
