export interface StudentPretragaResponse {
  studenti: StudentPretragaResponseStudent[];
}

export interface StudentPretragaResponseStudent {
  slikaKorisnika: string;
  id: number
  ime: string
  prezime: string
  opstinaRodjenjaNaziv: string
  opstinaRodjenjaDrzava: string
  datumRodjenja: string
  korisnickoIme: string
}
