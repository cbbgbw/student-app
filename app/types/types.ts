export enum EntityTypes {
  Projekt = 'Projekt',
  Egzamin = 'Egzamin',
  Wydarzenie = 'Wydarzenie',
  Przedmiot = 'Przedmiot',
}

export enum ModalType {
  None = 'None',
  AddSubject = 'AddSubject',
  AddProject = 'AddProject',
}

export const EntitiesModal: Record<string, ModalType> = {
  [EntityTypes.Przedmiot]: ModalType.AddSubject,
  [EntityTypes.Projekt]: ModalType.AddProject,
  [EntityTypes.Egzamin]: ModalType.AddProject,
  [EntityTypes.Wydarzenie]: ModalType.AddProject,
}
