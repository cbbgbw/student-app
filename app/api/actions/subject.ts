import { v4 as uuidv4 } from 'uuid'
import { Path, postByBody, postByScheme } from '../axios'

type Post = PostProps & {
  subjectKey: string
  semesterDefinitionKey: string | undefined
}

export interface PostProps {
  name: string
  description: string
  hasProjectToPass: boolean
  type: string
}

export const subjectPost = async (
  newSubject: PostProps,
  semesterDefinitionKey: string | undefined,
) => {
  const subject: Post = {
    ...newSubject,
    subjectKey: uuidv4(),
    semesterDefinitionKey: semesterDefinitionKey,
  }
  return postByScheme<Post>(Path.Subject, subject).then(
    () => subject.subjectKey,
  )
}
