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
    public class UploadService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SchoolDocument, SchoolDocumentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<SchoolDocumentDTO> Get()
        {
            var data = DataAccess.SchoolDocumentData();
            return GetMapper().Map<List<SchoolDocumentDTO>>(data.Get());
        }

        public static SchoolDocumentDTO Get(int id)
        {
            var data = DataAccess.SchoolDocumentData();
            return GetMapper().Map<SchoolDocumentDTO>(data.Get(id));
        }

        public static void Add(SchoolDocumentDTO SchoolDocumentDTO)
        {
            var data = DataAccess.SchoolDocumentData();
            var SchoolDocument = GetMapper().Map<SchoolDocument>(SchoolDocumentDTO);
            data.Add(SchoolDocument);
        }

        public static void Update(SchoolDocumentDTO SchoolDocumentDTO)
        {
            var data = DataAccess.SchoolDocumentData();
            var SchoolDocument = GetMapper().Map<SchoolDocument>(SchoolDocumentDTO);
            data.Update(SchoolDocument);
        }

        public static void Delete(int id)
        {
            var data = DataAccess.SchoolDocumentData();
            data.Delete(id);
        }
    }
}
