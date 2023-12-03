namespace FIT_Api_Example.Endpoints.Ispit.Update
{
    public class IspitUpdateRequest
    {
        public int Id { get; set; }
        public DateTime Satnica { get; set; }
        public string Komentar { get; set; }
    }
}
