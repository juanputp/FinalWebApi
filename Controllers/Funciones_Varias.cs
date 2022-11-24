using System.Security.Claims;

namespace FinalWebApi.Controllers
{
    public static class Funciones_Varias
    {

        public static bool ValidarToken(ClaimsIdentity identity)
        {

			try
			{

				if (identity.Claims.Count() == 0)
				{
					return false;
				}

                var perfil = identity.Claims.FirstOrDefault(x => x.Type == "Email");

                return true;

				
			}
			catch (Exception ex)
			{

				return false;
			}


        }


    }
}
