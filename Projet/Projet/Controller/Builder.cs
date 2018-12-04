using System.Reflection;
namespace Controller
{
    public class Builder
    {
        public Builder()
        {
            string type = MethodBase.GetCurrentMethod().DeclaringType.Name;
            if(type == "Serveur")
            {
                this.method = MoveServeur.method;
            }
        }

        public static object method;
    }
}