public class MesAno {
    public int MesInteiro { get; set; }
    public string MesString { get; set; }  
    public int Ano { get; set; }  
    public string MesComAno { get { return MesInteiro.ToString() + '/' + Ano.ToString();} }

}