using FIT_Api_Examples.Modul0_Autentifikacija.Models;

public class EmailLog
{
    public static void UspjesnoLogiranKorisnik(KorisnickiNalog logiraniKorisnik, HttpContext httpContext)
    {
        if (logiraniKorisnik != null && logiraniKorisnik.isNastavnik){
        EmailSender.Posalji(logiraniKorisnik.Email ,"New login",$" Login info : {DateTime.Now}");
        }
    }
}