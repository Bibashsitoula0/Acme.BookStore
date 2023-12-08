using Acme.BookStore.Dto;
using Acme.BookStore.Entity;
using Acme.BookStore.MessageHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace Acme.BookStore.Service
{
    public class StudentDomainService : IScopedDependency
    {
        private readonly IUnitOfWorkManager _uow;
        private readonly IRepository<Student, Guid> _studentRepo;
        public StudentDomainService(IUnitOfWorkManager uow, IRepository<Student, Guid> studentRepo)
        {
            _uow = uow;
            _studentRepo = studentRepo;

        }
        public async Task<Response<Student>> saveStudent(StudentDto dto)
        {
            var student = new Student();
            using var uow = _uow.Begin();
            if (dto.name.IsNullOrEmpty())
            {
                return Message.Error("Name should not be null", student);
            }

            student.StudentName = dto.name;
            await _studentRepo.InsertAsync(student);
            await uow.SaveChangesAsync();
            await uow.CompleteAsync();       
            return Message.SucessWithData("added sucessfully", student);
        }

                    
    }
}
