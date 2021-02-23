import { v4 as uuidv4 } from 'uuid'
import { Path, postByScheme, putByScheme } from '../axios'
import { Subject } from '../hooks/subject'

export type SubjectModel = SubjectCreateModel & {
  subjectKey: string
  semesterDefinitionKey: string | undefined
}

export interface SubjectCreateModel {
  name: string
  description: string
  hasProjectToPass: boolean
  type: string
}

export const subjectPost = async (
  newSubject: SubjectCreateModel,
  semesterDefinitionKey: string | undefined,
) => {
  const subject: SubjectModel = {
    ...newSubject,
    subjectKey: uuidv4(),
    semesterDefinitionKey: semesterDefinitionKey,
  }
  return postByScheme<SubjectModel>(Path.Subject, subject).then(
    () => subject.subjectKey,
  )
}

export const subjectPut = async (subjectModified: Subject) =>
  putByScheme<Subject>(Path.Subject, subjectModified)
