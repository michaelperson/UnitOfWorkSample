namespace UnitOfworkSample.UI.Models
{
    public class ClientFactureModel
    {
 
        private string _nom;
        private string _prenom;
        private string _numFacture;
        private double _montant;
        
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
      
        
        public string NumFacture { get => _numFacture; set => _numFacture = value; }
        public double Montant { get => _montant; set => _montant = value; }
    }
}
