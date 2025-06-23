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
    public class AuthService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static TokenDTO Auth(string email, string pass)
        {
            var user = DataAccess.AuthTeacher().Authenticate(email, pass);
            if (user != null)
            {
                Token tk = new Token();
                tk.Key = Guid.NewGuid().ToString();
                tk.CreatedAt = DateTime.Now;
                tk.ExpiredAt = null;
                tk.UserId = user.Id;

                var token = DataAccess.TokenData().Add(tk);
                return GetMapper().Map<TokenDTO>(token);
            }
            return null;
        }
        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.TokenData().Get(key);
            if (token != null && token.ExpiredAt == null) return true;
            return false;
        }
        public static TokenDTO Logout(string key)
        {
            var token = DataAccess.TokenData().Get(key);
            token.ExpiredAt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute - 2, DateTime.Now.Second);
            var rettk = DataAccess.TokenData().Update(token);
            return GetMapper().Map<TokenDTO>(rettk);
        }

    }
}
