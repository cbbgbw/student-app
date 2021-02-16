import useSWR from 'swr'
import { fetcher } from '../axios'

export interface Project {
  categoryKey: string
  categoryName: string
  deadlineTime: string
  description: string
  isArchive: boolean
  mark: number
  name: string
  necessaryToPass: boolean
  projectKey: string
  projectStatusKey: string
  projectStatusName: string
  subjectKey: string
  subjectTitle: string
  typeDefinitionKey: string
  typeDefinitionName: string
  workingAreaKey: string
}

export const useProjects = () => {
  const { data, error } = useSWR<Project[] | undefined>(
    'project/semester',
    fetcher,
  )

  const getAsKeyValue = () =>
    data?.reduce((prev, project) => {
      const { projectKey, name } = project
      return { ...prev, [projectKey]: name }
    }, {})

  return {
    projects: data,
    getAsKeyValue: getAsKeyValue,
  }
}

interface ProjectCount {
  countValue: number
  typeDefinitionKey: string
  typeName: string
}

export const useProjectCount = () => {
  const { data, error } = useSWR<ProjectCount[] | undefined>(
    'project/count',
    fetcher,
  )

  return {
    projectsCount: data,
  }
}
