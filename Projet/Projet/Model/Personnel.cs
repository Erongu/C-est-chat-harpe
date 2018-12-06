namespace Model
{
    public class Personnel
    {
        private int ID;
        private string prenom;
        private string nom;
        private string metier;
        private int posX;
        private int posY;


       

        //Getter 
        public int getID()
        {
            return this.ID;
        }

        public string getPrenom()
        {
            return this.prenom;
        }

        public string getNom()
        {
            return this.nom;
        }

        public string getMetier()
        {
            return this.metier;
        }

        public int getPosX()
        {
            return this.posX;
        }
        public int getPosY()

        {
            return this.posY;
        }

        public void setPosX(int posX)
        {
            this.posX = posX;
        }

        public void setPosY(int posY)
        {
            this.posY = posY;
        }
    }
}

