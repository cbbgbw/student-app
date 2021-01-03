import { v4 as uuidv4 } from 'uuid'

import { baseURL, Path, post } from './common/common'
import useSWR from 'swr'

type Post = PostProps & {
  subjectKey: string
  semester: number
}

export interface PostProps {
  name: string
  description: string
  hasProjectToPass: boolean
}

export const subjectPost = async (newSubject: PostProps) => {
  const subject: Post = {
    ...newSubject,
    subjectKey: uuidv4(),
    semester: 1,
  }
  return await post<Post>(Path.Subject, subject)
}

interface Subject {
  subjectKEY: string
  name: string
  description?: string
  statusDefinitionKey: string
  hasProjectToPass: boolean
  semester: number
  createTime: string
  modifyTime: string
  isArchive: boolean
}

export const useSubject = (key: string | string[] | undefined) => {
  if (key) {
    const { data, error } = useSWR(`${baseURL}/subject/${key}`)

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
