using CafeRestaurantOtomasyonu.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRestaurantOtomasyonu.DataLayerCustom
{
    public class Masa : DataLayer.Masa
    {
        public static DataTable MasaDetayiGetir(string aramaMetni)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string sorgu = @"SELECT MasaId, MasaAdi [Masa Adı], Aciklama [Açıklama]
                                 FROM MASA 
                                 WHERE MasaAdi LIKE @AramaMetni";


                dataTable = SqlHelper.GetDataTable(sorgu, new DinamikSqlParameter("@AramaMetni", aramaMetni.Replace('*', '%') + '%'));
            }
            catch (Exception ex)
            {
                dataTable = null;

                CommonHelper.WriteLog("MasaDetayiGetir", ex.Message);
            }
            return dataTable;

        }

        public static bool MasaIdMevcutMu(string masaAdi)
        {
            try
            {

                string sorgu = @"SELECT MasaId
                                 FROM MASA
                                 WHERE MasaAdi = @MasaAdi";

                object objMasaId = SqlHelper.GetScalarValue(sorgu,
                    new DinamikSqlParameter("@MasaAdi", masaAdi));


                return (objMasaId != null && objMasaId != DBNull.Value) && Convert.ToInt32(objMasaId) > 0;
            }
            catch (Exception ex)
            {
                CommonHelper.WriteLog("MasaIdMevcutMu", ex.Message);
                throw ex;
            }
        }
    }
}
