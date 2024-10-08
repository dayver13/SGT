using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SIRH.Web.PerfilUsuarioService;
//using SIRH.Web.PerfilUsuarioLocal;
using SIRH.DTO;
using System.Security.Cryptography;
using System.IO;

namespace SIRH.Web.Helpers
{
    public static class GestionUsuariosHelper
    {
        public static string UsuarioPermitido(CPerfilUsuarioServiceClient servicioUsuario, string nombreUsuario, int permiso, int perfil)
        {
            string respuesta;

            var dato = servicioUsuario.CargarPerfilUsuarioEspecifico(nombreUsuario, permiso,
                                                                        perfil);

            if (dato.GetType() == typeof(CErrorDTO))
            {
                if (((CErrorDTO)dato).MensajeError.StartsWith("El usuario no tiene permisos"))
                {
                    respuesta = "Denegado";
                }
                else
                {
                    respuesta = "Error " + ((CErrorDTO)dato).MensajeError;
                }
            }
            else
            {
                respuesta = "Autorizado";
            }

            return respuesta;
        }

        internal static string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "MAKV2SPBNI99212";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return cipherText;
            }
            catch (Exception error)
            {
                cipherText = "Error: " + error;
                return cipherText;
            }
        }

    }
}