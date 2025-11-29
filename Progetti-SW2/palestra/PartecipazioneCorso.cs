
public class PartecipazioneCorso
{
    private int _id;
    private DateTime _data;
    private bool _presente;
    private Corso? _corso;
    private Membro? _membro;
///////////////////////////////////////////////////////////////////////
    public int Id { get => _id; set => _id = value; }
    public DateTime Data { get => _data; set => _data = value; }
    public bool Presente { get => _presente; set => _presente = value; }
    public Corso Corso { get => _corso!; set => _corso = value; }
    public Membro Membro { get => _membro!; set => _membro = value; }
 //////////////////////////////////////////////////////////////////////
    public PartecipazioneCorso( int id,DateTime data,bool presente,Corso corso,Membro membro )
    {
        this._id=id;
        this._data=data;
        this._presente=presente;
        this._corso=corso;
        this._membro=membro;
    }
    public PartecipazioneCorso() :  this( 0,new DateTime(),false,null,null ) {}
    ////////////////////////////////////////////////////////////////////
    public void RegistraPresenza()
    {
        double frequenza = 0;
        
        frequenza +=1;
        if (this.Presente==true)
        {
        Console.WriteLine($"Il membro {_membro.Name} è stato registrato alle ore {DateTime.Now.ToString("HH:mm")}come presente al corso {_corso.XXXXXXXXXXXXXXXXXX}");
        frequenza +=1;
        }
    }
    public double VerificaFrequenza()
    {
        double frequenza =this.Data.Year/12;
        return frequenza;
    }
    public override string ToString()
    {
        return $"Id:{_id},Data:{_data.ToString("dd/MM/yyyy")},Presente:{_presente},Corso:{_corso.ToString()},Membro:{_membro.ToString()}";
    }
}