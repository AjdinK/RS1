export interface StudentGetallVM {
  id: number;
  ime: string;
  prezime: string;
  opstinaRodjenjaId: number | null;
  opstinaRodjenjaOpis: string;
  brojIndeksa: string;
  drzavaRodjenjaOpis: string;
  createdTime: string;
  slika_korisnika_nova_base64?: string | null;
  slika_korisnika_postojeca_base64_DB: string;
  slika_korisnika_postojeca_base64_FS: string;
  omiljeniPredmeti:any;
}
export interface StudentGetallVMPagedList {
  dataItems: StudentGetallVM []
  currentPage: number
  totalPages: number
  pageSize: number
  totalCount: number
  hasPrevios: boolean
  hasNext: boolean
}
