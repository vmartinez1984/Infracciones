using System;
using System.IO;

namespace Infracciones.Repositorio
{
    public class ImagenRepository
    {
        public static string Add(string nombreDelArchivo, int boletaDeSancionId, string base64)
        {
            try
            {
                string rutaDelArchivo;
                byte[] bytes;

                rutaDelArchivo = $@"{GetRaiz()}\{boletaDeSancionId.ToString().PadLeft(10, '0')}";
                if (Directory.Exists(rutaDelArchivo) == false)
                {
                    Directory.CreateDirectory(rutaDelArchivo);
                }
                bytes = Convert.FromBase64String(base64);
                rutaDelArchivo = $@"{rutaDelArchivo}\{nombreDelArchivo}.jpeg";
                File.WriteAllBytes(rutaDelArchivo, bytes);

                return rutaDelArchivo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string GetRaiz()
        {
            try
            {
                string raiz;
                DriveInfo[] drives;

                raiz = string.Empty;
                drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Fixed && (drive.Name.Contains("C") == false))
                    {
                        raiz = $@"{drive.Name}\RepositorioDeImagenes";
                        break;
                    }
                }
                if (Directory.Exists(raiz) == false)
                {
                    Directory.CreateDirectory(raiz);
                }

                return raiz;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
