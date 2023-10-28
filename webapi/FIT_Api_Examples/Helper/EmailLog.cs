using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

public class EmailLog
{
    public static void UspjesnoLogiranKorisnik(KorisnickiNalog logiraniKorisnik, HttpContext httpContext)
    {
        if (logiraniKorisnik != null && logiraniKorisnik.isNastavnik){
        EmailSender.Posalji(logiraniKorisnik.Email ,"New login",$" Login info : {DateTime.Now}");
        }
    }

    public static void noviNastavnik(Nastavnik nastavnik)
    {
        if (!nastavnik.isAktiviran){
            var url = "https://localhost:5001/Nastavnik/Aktivacija/" + nastavnik.AktivacijaGUID;
            var poruka = $"Postovani/a {nastavnik.ime}, <br> Link za aktivaciju <a href = '{url}'>{url}</a> ";
        EmailSender.Posalji(nastavnik.Email ,"Aktivacija korisnika",poruka);
        }
    }
}