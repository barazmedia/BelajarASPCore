using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BelajarASPCore.Models;
using Dapper;

namespace BelajarASPCore.DAL
{
    public class MahasiswaDAL : IMahasiswa
    {

        //mengambil configurasi dari appsetting.json
        private IConfiguration _config;
        public MahasiswaDAL(IConfiguration config)
        {
            _config = config;
        }

        //mengambil connection string
        private string getConStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }


        public IEnumerable<Mahasiswa> getAll()
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var strSql = "select * from mahasiswa order by nama";
                return Con.Query<Mahasiswa>(strSql);
            }
        }

        public IEnumerable<Mahasiswa> getByNim(string nim)
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var StrSql = "select * from mahasiswa where nim="+nim;
                return Con.Query<Mahasiswa>(StrSql);
            }
        }
    }
}