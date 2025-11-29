
public class Corso
{
    private int _id;
    private string _nome;
    private string _descrizione;
    private string _orario;
    private int _durataMinuti;
    private int _maxPartecipanti;
    private List<PartecipazioneCorso> _partecipazioni;
    private int _postiOccupati;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public int ID { get => _id; set => _id = value; }
    public string Nome { get => _nome; set => _nome = value; }
    public string Descrizione { get => _descrizione; set => _descrizione = value; }
    public string Orario { get => _orario; set => _orario = value; }
    public int DurataMinuti { get => _durataMinuti; set => _durataMinuti = value; }
    public int MaxPartecipanti { get => _maxPartecipanti; set => _maxPartecipanti = value; }
    public List<PartecipazioneCorso> Partecipazioni { get => _partecipazioni; set => _partecipazioni = value; }
    public int PostiOccupati { get => _postiOccupati; set => _postiOccupati = value; }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Corso(int id, string nome, string descrizione, string orario, int durataMinuti, int maxPartecipanti)
    {
        this._id = id;
        this._nome = nome;
        this._descrizione = descrizione;
        this._orario = orario;
        this._durataMinuti = durataMinuti;
        this._maxPartecipanti = maxPartecipanti;
        this._partecipazioni = new List<PartecipazioneCorso>();
        this._postiOccupati = PostiOccupati;
    }
    public Corso() : this(0, "", "", "", 0, 0) { }
    ////////////////////////////////////////////////////////////////////////////////////
    public bool VerificaDisponibilita()
    {
        // Verifica se ci sono posti liberi
        return _postiOccupati < _maxPartecipanti;
    }
    
    public bool AggiungiPartecipante(PartecipazioneCorso partecipazione)
    {
        // Verifica disponibilità
        if (!VerificaDisponibilita())
        {
            Console.WriteLine($"Impossibile aggiungere partecipante: corso '{_nome}' al completo.");
            return false;
        }
        
        // Verifica che la partecipazione non sia nulla
        if (partecipazione == null)
        {
            Console.WriteLine("Errore: partecipazione non valida.");
            return false;
        }
        
        // Verifica che il partecipante non sia già iscritto
        foreach (var p in _partecipazioni)
        {
            if (p.Membro != null && partecipazione.Membro != null && 
                p.Membro.Id == partecipazione.Membro.Id)
            {
                Console.WriteLine($"Il membro {partecipazione.Membro.Name} è già iscritto a questo corso.");
                return false;
            }
        }
        
        // Aggiunge il partecipante
        _partecipazioni.Add(partecipazione);
        _postiOccupati += 1;
        Console.WriteLine($"Partecipante aggiunto con successo al corso '{_nome}'. Posti disponibili: {PostiDisponibili()}");
        return true;
    }
    
    public bool RimuoviPartecipante(PartecipazioneCorso partecipazione)
    {
        // Verifica che la partecipazione non sia nulla
        if (partecipazione == null)
        {
            Console.WriteLine("Errore: partecipazione non valida.");
            return false;
        }
        
        // Cerca e rimuove il partecipante dalla lista
        bool rimosso = _partecipazioni.Remove(partecipazione);
        
        if (rimosso)
        {
            _postiOccupati--;
            Console.WriteLine($"Partecipante rimosso con successo dal corso '{_nome}'. Posti disponibili: {PostiDisponibili()}");
            return true;
        }
        else
        {
            Console.WriteLine("Errore: partecipante non trovato nel corso.");
            return false;
        }
    }
    
    public bool RimuoviPartecipantePerMembro(Membro membro)
    {
        // Metodo alternativo per rimuovere un partecipante cercando per ID del membro
        if (membro == null)
        {
            Console.WriteLine("Errore: membro non valido.");
            return false;
        }
        
        PartecipazioneCorso daRimuovere = null;
        foreach (var p in _partecipazioni)
        {
            if (p.Membro != null && p.Membro.Id == membro.Id)
            {
                daRimuovere = p;
                break;
            }
        }
        
        if (daRimuovere != null)
        {
            return RimuoviPartecipante(daRimuovere);
        }
        else
        {
            Console.WriteLine($"Il membro {membro.Name} non è iscritto a questo corso.");
            return false;
        }
    }
    
    public int PostiDisponibili()
    {
        // Calcola i posti disponibili
        return _maxPartecipanti - _postiOccupati;
    }
    
    public override string ToString()
    {
        return $"[Corso #{_id}] {_nome}\n" +
               $"Descrizione: {_descrizione}\n" +
               $"Orario: {_orario} | Durata: {_durataMinuti} minuti\n" +
               $"Partecipanti: {_postiOccupati}/{_maxPartecipanti} | Posti disponibili: {PostiDisponibili()}\n" +
               $"Iscritti: {(_partecipazioni.Count > 0 ? _partecipazioni.Count.ToString() : "Nessuno")}";
    }
}