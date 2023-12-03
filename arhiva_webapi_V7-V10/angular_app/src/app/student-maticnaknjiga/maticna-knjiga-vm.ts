export class MaticnaKnjigaVM {
  id: number
  ime: string
  prezime: string
  listaUpisi: ListaUpisi[]
  cijenaSkolarina: number
}

export class ListaUpisi {
  id: number
  godinaStudija: number
  jelObnova: boolean
  datumUpisZimski: string
  cijenaSkolarine: number
  datumOvjeraZimski: string
  evidentirao_korisnik: string
  akademska_godina_opis: string
  akademska_godina_id: number
}
