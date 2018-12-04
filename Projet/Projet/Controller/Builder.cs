namespace Controller
{
    public class Builder
    {
        public string type;
        public Builder()
        {
            thisObject = this;
            this.type = typeof(thisObject);
            if(this.type == "Serveur")
            {
                this.method = MoveServeur.method();
            }
        }
    }
}