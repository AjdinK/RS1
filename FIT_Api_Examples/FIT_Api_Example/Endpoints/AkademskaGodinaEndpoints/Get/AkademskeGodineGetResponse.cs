namespace FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Get;



public class AkademskeGodineGetResponse
{
    public List<AkademskeGodineGetResponseAkGodine> AkademskeGodine { get; set; }
}

public class AkademskeGodineGetResponseAkGodine
{
    public int Id { get; set; }
    public string Opis { get; set; }
}