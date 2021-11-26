using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Logistic
    {
        public List<City> GetCity()
        {
            ADOData objADOData = new ADOData();
            List<City> objCityList = new List<City>();
            DataTable objResult = new DataTable();
            SqlParameter[] sqlParameters = {
            };
            objResult = objADOData.ExecuteReaderWithDatatable("[dbo].[spGetCity]", sqlParameters);

            foreach (DataRow dtRow in objResult.Rows)
            {
                City objCity = new City();
                objCity.CityId = Convert.ToInt32(dtRow[0]);
                objCity.CityName = dtRow[1].ToString();
                objCityList.Add(objCity);
            }
            return objCityList;
        }

        public List<Kg> GetKg()
        {
            ADOData objADOData = new ADOData();
            List<Kg> objKgList = new List<Kg>();
            DataTable objResult = new DataTable();
            SqlParameter[] sqlParameters = {
            };
            objResult = objADOData.ExecuteReaderWithDatatable("[dbo].[spGetKg]", sqlParameters);

            foreach (DataRow dtRow in objResult.Rows)
            {
                Kg objKg = new Kg();
                objKg.KgId = Convert.ToInt32(dtRow[0]);
                objKg.KgName = Convert.ToInt32(dtRow[1]);
                objKgList.Add(objKg);
            }
            return objKgList;
        }

        public string GetZone(int City1,int City2)
        {
            ADOData objADOData = new ADOData();
            string result;
            SqlParameter[] sqlParameters = {
            new SqlParameter("@City1",City1),
            new SqlParameter("@City2",City2)
            };
            result = objADOData.ExecuteScalar("[dbo].[spGetZonebyCity]", sqlParameters);
            return result;
        }

        public string getValueByZone(string Zone, int Kg)
        {
            ADOData objADOData = new ADOData();
            string result;
            SqlParameter[] sqlParameters = {
            new SqlParameter("@Zone",Zone),
            new SqlParameter("@Kg",Kg)
            };
            result = objADOData.ExecuteScalar("[dbo].[spGetValueByZone]", sqlParameters);
            return result;
        }
    }
}
