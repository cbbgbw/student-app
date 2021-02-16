import useSWR from 'swr'
import { fetcher } from '../axios'

export interface Subject {
  subjectKey: string
  name: string
  description?: string
  typeDefinitionKey: string
  typeDefinitionName: string
  hasProjectToPass: boolean
  semester: number
  createTime: string
  modifyTime: string
  isArchive: boolean
  isPassed: boolean
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
export const useSubjects = () => {
  const { data, mutate, error } = useSWR<Subject[] | undefined>(
    `subject/semester`,
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
    reFetch: mutate,
  }
}

export const useSubject = (key: string | undefined) => {
  const { data, error } = useSWR<Subject | undefined>(
    key ? `subject/${key}` : null,
    fetcher,
  )

  return {
    isLoading: !data && !error,
    subject: data,
  }
}
