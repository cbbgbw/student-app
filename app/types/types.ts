export enum EntityTypes {
  Projekt = 'Projekt',
  Egzamin = 'Egzamin',
  Wydarzenie = 'Wydarzenie',
  Przedmiot = 'Przedmiot',
}

export enum ModalType {
  None = 'None',
  AddSubject = 'AddSubject',
  AddExam = 'AddExam',
  AddProject = 'AddProject',
  AddEvent = 'AddEvent',
}

export const EntitiesModal: Record<string, ModalType> = {
  [EntityTypes.Przedmiot]: ModalType.AddSubject,
  [EntityTypes.Projekt]: ModalType.AddProject,
  [EntityTypes.Egzamin]: ModalType.AddExam,
  [EntityTypes.Wydarzenie]: ModalType.AddEvent,
}
