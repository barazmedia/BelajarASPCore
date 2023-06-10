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

        public void Insert(Mahasiswa mhs)
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var strSql = @"insert into Mahasiswa (nim,nama,alamat,email,telpon) 
                            values (@Nim, @Nama, @Alamat, @Email, @Telpon)";
                try {
                    var param = new {Nim = mhs.Nim, Nama = mhs.Nama, Alamat = mhs.Alamat, Email = mhs.Email, Telpon = mhs.Telpon};
                    Con.Execute(strSql, param);
                }
                catch(SqlException ex)
                {
                    throw new Exception($"Error : {ex.Message}");
                }
            }
        }

        public Mahasiswa getById(string nim)
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var strSql = @"select * from mahasiswa where nim=@Nim";
                var param = new {nim = nim};
                var data = Con.QuerySingleOrDefault<Mahasiswa>(strSql,param);
                if(data != null){
                    return data;
                }
                else{
                    throw new Exception("Data tidak ditemukan !");
                }
            }            
        }

        public void Update(Mahasiswa mhs)
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var strSql =@"update mahasiswa set nama=@nama,alamat=@alamat,email=@email,telpon=@telpon
                            where nim=@nim";

                try {
                    var param = new {nama=mhs.Nama, alamat=mhs.Alamat, email=mhs.Email, telpon=mhs.Telpon, nim=mhs.Nim};
                    Con.Execute(strSql,param);
                }
                catch(SqlException ex){
                    throw new Exception($"Error : {ex.Message}");
                }
            }
        }

        public void Delete(string nim)
        {
            using(SqlConnection Con = new SqlConnection(getConStr()))
            {
                var strSql = @"delete from mahasiswa where nim=@nim";                
                try {
                    var param = new {nim=nim};
                    Con.Execute(strSql, param);
                }
                catch(SqlException SqlEx)
                {
                    throw new Exception($"Error : {SqlEx.Message}");
                }
            }
        }
    }
}