﻿namespace FIT_Api_Example.Endpoints.AuthEndpoints.Login;
public class AuthLoginRequest
{
    public string SignalRConnectionID { get; set; }
    public string KorisnickoIme { get; set; }
    public string Lozinka { get; set; }
}