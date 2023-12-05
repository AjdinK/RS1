namespace FIT_Api_Example.Endpoints.StudentEndpoints.ProfileImageSnimi;

public class StudentProfileImageSnimiRequest
{
    public int StudentId { get; set; }
    public IFormFile SlikaStudenta { set; get; }
}