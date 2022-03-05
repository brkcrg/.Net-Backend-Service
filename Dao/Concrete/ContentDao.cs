using InsaatAPI.Dao.Abstract;
using InsaatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InsaatAPI.Dao
{
    public class ContentDao : IContent
    {
        InsaatContext context = new InsaatContext();
        public string GetCityList()
        {
            var cities = context.Cities.ToList();
            var resultjson = JsonConvert.SerializeObject(new[] {
                new {
                    Result = "İşlem Başarılı",
                    Message = "",
                    CityTable = cities
                }
            });

            return resultjson;
        }
        public async Task<string> PostCity([FromBody] City req)
        {
            var cities = new City
            {
                CityName = req.CityName
            };

            context.Cities.Add(cities);
            await context.SaveChangesAsync();

            var resultjson = JsonConvert.SerializeObject(new
            {
                Result = "Succes.",
            });

            return resultjson;
        }
        public async Task<string> PutCity([FromBody] City req)
        {
            var city = context.Cities.FirstOrDefault(c => c.CityID == req.CityID);
            city.CityName = req.CityName;
            //city.UpdateDate = DateTime.Now;Sql deupdate date yok oyüzden hata veriyo.
            await context.SaveChangesAsync();
           

            var resultjson = JsonConvert.SerializeObject(new
            {
                Result = "Succes.",
            });

            return resultjson;
        }
        public async Task<string> DeleteCity([FromBody] City req)
        {
            var city = context.Cities.FirstOrDefault(c => c.CityID == req.CityID);
         
            
            context.Remove(city);
            await context.SaveChangesAsync();


            var resultjson = JsonConvert.SerializeObject(new
            {
                Result = "Succes.",
            });

            return resultjson;
        }
        public async  Task<string> GetFlatTypeList()
        {
            var con = new SqlConnection(@"Server=DESKTOP-L6GAVKA;Database=Insaat;User ID=sa;Password=1234;");
            con.Open();

            var query = "SELECT FlatTypeID,FlatTypeName FROM FlatType";
            var cmd = new SqlCommand(query, con);
            SqlDataReader reader =await cmd.ExecuteReaderAsync();//dışarıya bağlı bir işlem olduğu için bburaya await async koyuyoruz.
            var dt = new DataTable();
            dt.Load(reader);
            List<DataRow> result = dt.AsEnumerable().ToList();
            reader.Close();
            con.Close();
            var resultjson = JsonConvert.SerializeObject(new[]
            {
                new{
                Result = "Success.",
                FlatTypeTable=result.CopyToDataTable(),
            } });

            return resultjson;
        }
    }


}
