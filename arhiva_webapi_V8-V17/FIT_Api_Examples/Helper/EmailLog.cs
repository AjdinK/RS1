using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

public class EmailLog
{
    public static void UspjesnoLogiranKorisnik(AutentifikacijaToken token, HttpContext httpContext)
    {
        var logiraniKorisnik = token.korisnickiNalog;
        if (logiraniKorisnik.isNastavnik || logiraniKorisnik.isAdmin)
        {
            var poruka = $"Postovani/a {logiraniKorisnik.KorisnickoIme}<br>" +
            "Code za Two factor je " +
             $"<b>{token.twoFactorCode}</b><br>" +
             $"Login info {DateTime.Now}";
            EmailSender.Posalji(logiraniKorisnik.Email, "Code za two factor authorizacije", poruka, true);
        }
    }

    public static void noviNastavnik(Nastavnik nastavnik, HttpContext httpContext)
    {
        if (!nastavnik.isAktiviran)
        {
            var request = httpContext.Request;
            var location = $"{request.Scheme}://{request.Host}";
            var url = location + "/Nastavnik/Aktivacija/" + nastavnik.AktivacijaGUID;
            var poruka = $"Postovani/a {nastavnik.Ime}, <br> Link za aktivaciju <a href = '{url}'>{url}</a> ";
            EmailSender.Posalji(nastavnik.Email, "Aktivacija korisnika", poruka, true);
        }
    }
}