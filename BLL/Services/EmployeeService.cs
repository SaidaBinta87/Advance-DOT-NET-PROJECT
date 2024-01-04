using AutoMapper;
using BLL.DTOs;
using DLL;
using DLL.EF.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> GetAll()
        {
            var data = DataAccessFactory.EmployeeData().Get();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<EmployeeDTO>>(data);
            return ret;
        }

        public static EmployeeDTO Create(EmployeeDTO ps)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            var mapper = new Mapper(config);

            var data = mapper.Map<Employee>(ps);
            var ret = DataAccessFactory.EmployeeData().Create(data);

            var data2 = mapper.Map<EmployeeDTO>(ret);
            return data2;
        }

        public static EmployeeDTO Update(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            var mapper = new Mapper(config);

            var employee = mapper.Map<Employee>(employeeDTO);
            var result = DataAccessFactory.EmployeeData().Update(employee);

            if (result != null)
            {
                var updatedEmployeeDTO = mapper.Map<EmployeeDTO>(result);
                return updatedEmployeeDTO;
            }

            return null; 
        }

        public static EmployeeDTO GetEmp(string email, string password)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            var mapper = new Mapper(config);

          
            var result = DataAccessFactory.EmployeeData().Authenticate(email,password);
            var dataDTO = mapper.Map<EmployeeDTO>(result);
            return dataDTO;


        }


        public static string Delete(int email)
        {
            var result = DataAccessFactory.EmployeeData().Delete(email);
            return result ? "Delete successfully" : "Failed";
        }


        

        public static List<MgsDTO> GetAllQuestion()
        {
            var data = DataAccessFactory.EmpMgsData().Get();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserQuestions, MgsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<MgsDTO>>(data);
            return ret;
        }

       

        public static MgsDTO UpdateQuestion(MgsDTO mgsDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MgsDTO, UserQuestions>();
                cfg.CreateMap<UserQuestions, MgsDTO>();
            });

            var mapper = new Mapper(config);

            var employee = mapper.Map<UserQuestions>(mgsDTO);
            var result = DataAccessFactory.EmpMgsData().Update(employee);

            if (result != null)
            {
                var updatedEmployeeDTO = mapper.Map<MgsDTO>(result);
                return updatedEmployeeDTO;
            }

            return null; 
        }

       


        public static string DeleteQuestion(int email)
        {
            var result = DataAccessFactory.EmpMgsData().Delete(email);
            return result ? "Delete successfully" : "Failed";
        }

        public static List<MgsDTO> GetAll(int id)
        {
            var data = DataAccessFactory.EmpMgsData().GetAll(id);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserQuestions, MgsDTO>();
            });
            var mapper = new Mapper(config);
            var ret = mapper.Map<List<MgsDTO>>(data);
            return ret;
        }
    }
}
