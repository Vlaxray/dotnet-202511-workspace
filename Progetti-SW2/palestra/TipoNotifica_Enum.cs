using System;
using System.ComponentModel;

public enum TipoNotifica
{
    [Description("Abbonamento in scadenza!")]
    PromemoriaPagamento,
    
    [Description("Promemoria corsi disponibili")]
    PromemoriaCorsi,
    
    [Description("Offerta rinnovo disponibile")]
    OffertaRinnovo,
    
    [Description("Messaggio di sistema")]
    Sistema
}