export interface StudentOldGetAllResponse {
  ime: string
  prezime: string
  brojIndeksa: string
  opstinaRodjenjaID: number
  opstinaRodjenja: StudentOldGetAllResponseOpstinaRodjenja
  datumRodjenja: string
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

export interface StudentOldGetAllResponseOpstinaRodjenja {
  id: number
  description: string
  drzavaID: number
  drzava: StudentOldGetAllResponseDrzava
}


export interface StudentOldGetAllResponseDrzava {
  id: number
  naziv: string
  skracenica: any
}
