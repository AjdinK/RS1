export interface StudentSedmica5Response {
  ime: string
  prezime: string
  brojIndeksa: string
  opstinaRodjenjaID: number
  opstinaRodjenja: StudentSedmica5ResponseOpstinaRodjenja
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

export interface StudentSedmica5ResponseOpstinaRodjenja {
  id: number
  description: string
  drzavaID: number
  drzava: StudentSedmica5ResponseDrzava
}


export interface StudentSedmica5ResponseDrzava {
  id: number
  naziv: string
  skracenica: any
}
