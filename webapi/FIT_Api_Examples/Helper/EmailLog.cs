using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

public class EmailLog
{
    public static void UspjesnoLogiranKorisnik(KorisnickiNalog logiraniKorisnik, HttpContext httpContext)
    {
        if (logiraniKorisnik != null && logiraniKorisnik.isNastavnik){
        EmailSender.Posalji(logiraniKorisnik.Email ,"New login",$" Login info : {DateTime.Now}" , false);
        }
    }

    public static void noviNastavnik(Nastavnik nastavnik , HttpContext httpContext)
    {
        if (!nastavnik.isAktiviran){
            var request = httpContext.Request;
            var location = $"{request.Scheme}://{request.Host}";
            var url = location + "/Nastavnik/Aktivacija/" + nastavnik.AktivacijaGUID;
            var poruka = $"Postovani/a {nastavnik.ime}, <br> Link za aktivaciju <a href = '{url}'>{url}</a> ";
        EmailSender.Posalji(nastavnik.Email ,"Aktivacija korisnika",poruka , true);
        }
    }
}