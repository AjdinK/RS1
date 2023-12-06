export interface AuthLoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}

export interface AutentifikacijaToken {
  id: number
  vrijednost: string
  korisnickiNalogId: number
  korisnickiNalog: KorisnickiNalog
  vrijemeEvidentiranja: string
  ipAdresa: string
}

export interface KorisnickiNalog {
  id: number
  korisnickoIme: string
  slikaKorisnika: string
  isNastavnik: boolean
  isStudent: boolean
  isAdmin: boolean
  isProdekan: boolean
  isDekan: boolean
  isStudentskaSluzba: boolean
}
