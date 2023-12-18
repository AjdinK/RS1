namespace FIT_Api_Example.Endpoints.OpstinaEndpoints.GetAll
{
    public record OpstinaGetAllResponse(List<OpstinaGetAllResponseOpstina> Opstine);

    public record OpstinaGetAllResponseOpstina(int Id, string Opis);

}
