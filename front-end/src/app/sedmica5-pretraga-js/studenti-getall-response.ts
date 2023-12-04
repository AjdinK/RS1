export interface StudentiGetAllResponse{
  studenti: StudentiGetAllResponseStudent[]

}

export interface StudentiGetAllResponseStudent {
  slikaKorisnika: string;
  id: number
  ime: string
  prezime: string
  opstinaRodjenjaNaziv: string
  opstinaRodjenjaDrzava: string
  datumRodjenja: string
  korisnickoIme: string
}
