//ovdje dodati Student6PretragaResponse

//ovdje dodati Student6PretragaResponseStudenti

export interface Student6PretragaResponse {
  studenti: Student6PretragaResponseStudenti[]
}

export interface Student6PretragaResponseStudenti {
  id: number
  ime: string
  prezime: string
  opstinaRodjenjaNaziv: string
  opstinaRodjenjaDrzava: string
  datumRodjenja: string
  korisnickoIme: string
  slikaKorisnika: string
}
