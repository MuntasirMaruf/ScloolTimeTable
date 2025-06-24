using AutoMapper;
using SchoolTimeTableBLL.DTOs;
using SchoolTimeTableDAL;
using SchoolTimeTableDAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.Services
{
    public class StudentAuthService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TokenStudent, TokenStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static TokenStudentDTO Auth(string email, string pass)
        {
            var user = DataAccess.AuthStudent().Authenticate(email, pass);
            if (user != null)
            {
                TokenStudent tk = new TokenStudent();
                tk.Key = Guid.NewGuid().ToString();
                tk.CreatedAt = DateTime.Now;
                tk.ExpiredAt = null;
                tk.UserId = user.Id;

                var token = DataAccess.TokenStudentData().Add(tk);
                return GetMapper().Map<TokenStudentDTO>(token);
            }
            return null;
        }
        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.TokenStudentData().Get(key);
            if (token != null && token.ExpiredAt == null) return true;
            return false;
        }
        public static TokenStudentDTO Logout(string key)
        {
            var token = DataAccess.TokenStudentData().Get(key);
            token.ExpiredAt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute - 2, DateTime.Now.Second);
            var rettk = DataAccess.TokenStudentData().Update(token);
            return GetMapper().Map<TokenStudentDTO>(rettk);
        }
    }
}
