import { v4 as uuidv4 } from 'uuid'

import { post } from './common/common'
import useSWR from 'swr'
import { fetcher, Path } from '../api/axios'

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
  return post<Post>(Path.Subject, subject).then(() => subject.subjectKey)
}

interface Subject {
  subjectKey: string
  name: string
  description?: string
  typeDefinitionKey: string
  hasProjectToPass: boolean
  semester: number
  createTime: string
  modifyTime: string
  isArchive: boolean
}

export const useSubject = (key: string | string[] | undefined) => {
  if (key) {
    const { data, error } = useSWR(`subject/${key}`, fetcher)

    return {
      subject: data,
      isLoading: !error && !data,
      isError: error,
    }
  } else {
    return {
      subject: undefined,
      isLoading: undefined,
      isError: undefined,
    }
  }
}

export const useSubjectTypes = () => {
  const { data, error } = useSWR<Record<string, string>>(
    `subject/types`,
    fetcher,
  )

  return {
    subjectTypes: data,
    isLoading: !error && !data,
    isError: error,
  }
}

export const useSubjectsBySemester = (semesterKey: string | undefined) => {
  const { data, error } = useSWR<Subject[] | undefined>(
    semesterKey ? `subject/list/${semesterKey}` : null,
    fetcher,
  )

  const getAsKeyValue = () =>
    data?.reduce((prev, subject) => {
      const { subjectKey, name } = subject
      return { ...prev, [subjectKey]: name }
    }, {})

  return {
    getAsKeyValue: getAsKeyValue,
    subjectArray: data,
    isLoading: !error && !data,
    isError: error,
  }
}
