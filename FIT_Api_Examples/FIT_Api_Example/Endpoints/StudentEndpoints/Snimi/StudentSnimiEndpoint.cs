using Azure.Core;
using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using FIT_Api_Example.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.Snimi;

[Route("student")]
[MyAuthorization]
public class StudentSnimiEndpoint : MyBaseEndpoint<StudentSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    private readonly IHubContext<SignalRHub> _hubContext;

    public StudentSnimiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService, IHubContext<SignalRHub> hubContext)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
        _hubContext = hubContext;
    }

    [HttpPost("snimi")]
    public override async Task<int> Obradi([FromBody] StudentSnimiRequest request, CancellationToken cancellationToken)
    {
       
        Data.Models.Student? student;
        if (request.ID == 0)
        {
            student = new Data.Models.Student();
            _applicationDbContext.Add(student);

            student.SlikaKorisnika = Config.SlikeURL + "empty.png";
        }
        else
        {
            student = _applicationDbContext.Student.Include(s => s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == request.ID);
            if (student == null)
                throw new Exception("pogresan ID");
        }

        student.Ime = request.Ime.RemoveTags();
        student.Prezime = request.Prezime.RemoveTags();
        //student.BrojIndeksa = request.BrojIndeksa;
        //student.DatumRodjenja = request.DatumRodjenja;
        student.OpstinaRodjenjaID = request.OpstinaRodjenjaID;

        if (!string.IsNullOrEmpty(request.Slika_base64_format))
        {
            byte[]? slika_bajtovi = request.Slika_base64_format?.ParsirajBase64();

            if (slika_bajtovi == null)
                throw new Exception("pogresan base64 format");

            byte[]? slika_bajtovi_resized_velika = resize(slika_bajtovi, 200);
            if (slika_bajtovi_resized_velika == null)
                throw new Exception("pogresan format slike");

            byte[]? slika_bajtovi_resized_mala = resize(slika_bajtovi, 50);
            if (slika_bajtovi_resized_mala == null)
                throw new Exception("pogresan format slike");

            var folderPath = "slike-studenata";
            if (!Directory.Exists(folderPath))
            {
                // Create the folder if it does not exist
                Directory.CreateDirectory(folderPath);
            }

            student.SlikaKorisnikaMala = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";
            student.SlikaKorisnikaVelika = $"{folderPath}/{Guid.NewGuid().ToString()}.jpg";

            await System.IO.File.WriteAllBytesAsync(student.SlikaKorisnikaMala, slika_bajtovi_resized_velika, cancellationToken);
            await System.IO.File.WriteAllBytesAsync(student.SlikaKorisnikaVelika, slika_bajtovi_resized_mala, cancellationToken);

            //1- file system od web servera ili neki treci servis kao sto je azure blob store ili aws 
        }
  
        
        await _hubContext.Clients.All.SendAsync("prijem_poruke_js", "student updated " + student.BrojIndeksa,
                cancellationToken: cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return student.ID;
    }

    public static byte[]? resize(byte[] slikaBajtovi, int size, int quality = 75)
    {
        using var input = new MemoryStream(slikaBajtovi);
        using var inputStream = new SKManagedStream(input);
        using var original = SKBitmap.Decode(inputStream);
        int width, height;
        if (original.Width > original.Height)
        {
            width = size;
            height = original.Height * size / original.Width;
        }
        else
        {
            width = original.Width * size / original.Height;
            height = size;
        }

        using var resized = original
            .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);
        if (resized == null) return null;

        using var image = SKImage.FromBitmap(resized);
        return image.Encode(SKEncodedImageFormat.Jpeg, quality)
            .ToArray();
    }
}