using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.Models
{
    public static class BaseRestApiServices
    {
        #region Logowanie

        public static string ServiceServerLogowanie => "http://localhost:54737"; //"http://172.16.64.15/AluplastTerminale.Logowanie";

        //public static string ServiceServer => "http://172.16.64.15/AluplastTerminale.Logowanie";
        //public static string ServiceServerVS => "http://localhost:54737";
        //public static string ServiceServerLocalIIS => "http://172.16.65.96/AluplastTerminale.Logowanie";
        #endregion

        #region Kompletacja
        public static string ServiceServerKompletacja => "http://172.16.64.15/Kompletacja10";

        //public string ServiceServer => "http://172.16.64.15/Kompletacja10";
        //public string ServiceServerVS => "http://localhost:51236";
        //public string ServiceServerLocalIIS => "http://172.16.65.96/Kompletacja";
        #endregion

        #region KontrolaZaladunku
        public static string ServiceServerKontrolaZaladunku => "http://localhost:58892"; //"http://172.16.64.15/KontrolaZaladunku";

        //public string ServiceServer => "http://172.16.64.15/KontrolaZaladunku";
        //public string ServiceServerVS => "http://localhost:58892";
        //public string ServiceServerLocalIIS => "http://172.16.65.96/ControlLoader";
        #endregion

        #region ZmianaLokalizacji
        public static string ServiceServerZmianaLokalizacji => "http://localhost:60225"; //"http://172.16.64.15/ZmianaLokalizacji";

        //public string ServiceServer => "http://172.16.64.15/ZmianaLokalizacji";
        //public string ServiceServerVS => "http://localhost:60225";
        //public string ServiceServerLocalIIS => "http://172.16.65.96/ZmianaLokalizacji";
        #endregion

        #region Inwentaryzacja
        public static string ServiceServerInwentaryzacja => "http://172.16.64.15/Inwentaryzacja";

        //public string ServiceServer => "http://172.16.64.15/Inwentaryzacja";
        //public string ServiceServerVS => "http://localhost:54737";
        //public string ServiceServerLocalIIS => "http://172.16.65.96/Inwentaryzacja";
        #endregion



    }
}
