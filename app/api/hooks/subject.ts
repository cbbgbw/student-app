import useSWR from 'swr'
import { fetcher } from '../axios'

export interface Subject {
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
  const { data, error } = useSWR<Subject[] | undefined>(
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
  }
}
